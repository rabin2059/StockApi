using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllSync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdSync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}