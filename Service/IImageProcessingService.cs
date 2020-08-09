using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Service
{
    public interface IImageProcessingService
    {
        public Task Process(ImageFile fileName);

        public bool IsFileNotEmpty(ImageFile file);
    }
}