using GaleryApp.Models.Abstract;
using GaleryApp.Models.Interface;
using Newtonsoft.Json;

namespace GaleryApp.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IEntity
    {
        private readonly string _filePath;
         private int _lastId;
        public GenericRepository(string filePath)
        //constructor
        {
            // Sınıf ilk oluşturulduğunda çalışır. Parametre olarak bir dosya yolu alır (filePath) ve bu yolu _filePath adlı özel alana atar.
            _filePath = filePath; //Parametre olarak gelen filePath değişkeni, sınıfın içinde kullanılmak üzere _filePath alanına atanır.
            if (!File.Exists(_filePath))//Dosya belirtilen yolda var mı diye kontrol eder.
            {
                //Eğer dosya yoksa, JSON formatında boş bir dizi ([]) içeren bir dosya oluşturur. Bu, nesne koleksiyonlarını saklamak için başlangıç veri yapısıdır.
                File.WriteAllText(_filePath, "[]");
            }
            //Dosyadan tüm verileri okuyan GetAll() metodu çağrılır ve dönen veri entities adlı değişkene atanır. Bu, daha önce kaydedilmiş tüm nesneleri içerir.
            var entities = GetAll();
            //Eğer entities içinde en az bir kayıt varsa (Count > 0), en büyük Id değeri bulunur (entities.Max(e => e.Id)), bu değer _lastId değişkenine atanır.
            _lastId = entities.Count > 0 ? entities.Max(e => e.Id) : 0;//Eğer hiç kayıt yoksa _lastId = 0 olarak ayarlanır. Bu işlem, yeni eklenecek öğelere otomatik olarak bir sonraki uygun ID'yi verebilmek için yapılır.
            _filePath = filePath;
        }

       
       public void Create(T entity)
        {
            _lastId++;
            entity.Id = _lastId;
            var entities = GetAll();
            entities.Add(entity);
            SaveAll(entities);
        }

        public void Delete(int id)
        {
            var entities = GetAll();
            var entity = entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                entities.Remove(entity);
                SaveAll(entities);
            }
        }

        public List<T> GetAll()
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            var entities = GetAll();
            var index = entities.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                entities[index] = entity;
                SaveAll(entities);
            }
        }

        private void SaveAll(List<T> entities)
        {
            var json = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
