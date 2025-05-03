using GaleryApp.Models.Interface;

namespace GaleryApp.Models.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
    }
}
