using GaleryApp.Models.Abstract;
using GaleryApp.Models.Interface;

namespace GaleryApp.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IEntity
    {
        private readonly string _filePath;

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

        private int _lastId;
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
