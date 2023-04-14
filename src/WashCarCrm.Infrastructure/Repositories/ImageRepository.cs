using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class ImageRepository : GenericRepository<Image, int>, IImageRepository
    {
        public ImageRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<Image> InsertImageAsync(Image Image)=>
            base.InsertAsync(Image);
        public IQueryable<Image> SelectAllImages() =>
            base.SelectAll();
        public ValueTask<Image> SelectImageByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<Image> UpdateImageAsync(Image Image) =>
            base.UpdateAsync(Image);

        public ValueTask<Image> DeleteImageAsync(Image Image) =>
            base.DeleteAsync(Image);
    }
}