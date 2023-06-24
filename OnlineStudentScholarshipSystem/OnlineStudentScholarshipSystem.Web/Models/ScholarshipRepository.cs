namespace OnlineStudentScholarshipSystem.Web.Models
{
    public class ScholarshipRepository
    {

        private static List<Scholarship> _scholarships=new List<Scholarship>();
        public List<Scholarship> getAllScholarship() => _scholarships;

        public void addScholarship(Scholarship newProduct) => _scholarships.Add(newProduct);

        public void removeScholarship(int id)
        {
            var hasProduct = _scholarships.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"There is no product with this id({id}).");//There is no product with this id({id}).
            }

            _scholarships.Remove(hasProduct);



        }

        public void updateScholarship(Scholarship updateProduct)
        {
            var hasProduct = _scholarships.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"There is no product with this id({updateProduct.Id}).");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Amount = updateProduct.Amount;
            hasProduct.ApplicationCriteria = updateProduct.ApplicationCriteria;
            hasProduct.Foundation = updateProduct.Foundation;
            hasProduct.PublishDate = updateProduct.PublishDate;
            hasProduct.Deadline = updateProduct.Deadline;


            var index = _scholarships.FindIndex(x => x.Id == updateProduct.Id);

            _scholarships[index] = hasProduct;




        }
    }
}
