using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
    public interface IImageRepository : IGenericRepository<Image, int>
    {
        ValueTask<Image> InsertImageAsync(Image Image);
        IQueryable<Image> SelectAllImages();
        ValueTask<Image> SelectImageByIdAsync(int id);
        ValueTask<Image> UpdateImageAsync(Image Image);
        ValueTask<Image> DeleteImageAsync(Image Image);
    }
}