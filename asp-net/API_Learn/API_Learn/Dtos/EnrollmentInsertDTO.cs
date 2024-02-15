using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class EnrollmentInsertDTO
    {

        public int OfferId { get; set; }
        public string UserId { get; set; }
    
        public bool OnlyUpdate { get; set; }

    }
}