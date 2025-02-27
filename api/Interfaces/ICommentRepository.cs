using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment stockModel);
        Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto CommentDto);
        Task<Comment?> DeleteAsync(int id);
    }
}