using Backend.DTOs;

namespace Backend.services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
