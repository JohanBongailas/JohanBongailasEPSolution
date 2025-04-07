using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Handles CRUD operations for Poll entities. 
    /// </summary>
    public class PollRepository
    {
        // Inject the DbContext instance using DI to interact with the database
        private readonly PollDbContext _context;
        public PollRepository(PollDbContext context)
        {
            _context = context;
        }
        public void CreatePoll(string title, string option1Text, 
                               string option2Text, string option3Text, 
                               int option1VotesCount, int option2VotesCount, int option3VotesCount)
        {

            _context.Polls.Add(new() 
            {
                Title = title,
                Option1Text = option1Text,
                Option2Text = option2Text,
                Option3Text = option3Text,
                Option1VotesCount = option1VotesCount,
                Option2VotesCount = option2VotesCount,
                Option3VotesCount = option3VotesCount,
            });

            _context.SaveChanges();
        }

        public IQueryable GetPolls()
        {
            return _context.Polls;
        }
    }
}
