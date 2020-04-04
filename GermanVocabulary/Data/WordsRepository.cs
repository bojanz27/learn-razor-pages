using GermanVocabulary.Data.Model;
using GermanVocabulary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GermanVocabulary.Data
{
    public class WordsRepository
    {
        private readonly GermanVocabularyDbContext _dbContext;

        public WordsRepository(GermanVocabularyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Words>> GetWords()
        {
            return await _dbContext.Words.ToListAsync();
        }

        public async Task<List<Words>> FilterGermanWords(FilterWordsDTO filterDTO)
        {
            return await _dbContext.Words
                .Where(w=>w.German.ToLower().Contains(filterDTO.Word.ToLower())).ToListAsync();
        }

        public async Task<List<Words>> FilterSerbianWords(FilterWordsDTO filterDTO)
        {
            return await _dbContext.Words
                .Where(w => w.Serbian.ToLower().Contains(filterDTO.Word.ToLower())).ToListAsync();
        }

        public async Task AddWord(AddWordDTO addWordDTO) 
        {
            _dbContext.Words.Add(new Words { German = addWordDTO.German, Serbian = addWordDTO.Serbian });
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Words word = await _dbContext.Words.FindAsync(id);
            _dbContext.Words.Remove(word);
            await _dbContext.SaveChangesAsync();
        }
    }
}
