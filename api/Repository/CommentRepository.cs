using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment stockModel)
        {
            await _context.Comments.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var DataModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (DataModel == null)
            {
                return null;
            }
            _context.Comments.Remove(DataModel);
            await _context.SaveChangesAsync();
            return DataModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto CommentDto)
        {
            var existingData = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingData == null)
            {
                return null;
            }
            existingData.Title = CommentDto.Title;
            existingData.Content = CommentDto.Content;
            existingData.CreatedOn = CommentDto.CreatedOn;
            existingData.StockId = CommentDto.StockId;


            await _context.SaveChangesAsync();

            return existingData;
        }
    }
}