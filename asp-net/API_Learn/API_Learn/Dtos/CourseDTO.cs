using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public string ImgGrayUri { get; set; }


        public CourseDTO(Course entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.ImgUri = entity.ImgUri;
            this.ImgGrayUri = entity.ImgGrayUri;
        }
    }
}
