using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GermanVocabulary.Data;
using GermanVocabulary.Data.Model;
using GermanVocabulary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GermanVocabulary.Pages
{
    public class VocabularyModel : PageModel
    {
        private readonly WordsRepository _wordsRepository;

        public List<Words> Words { get; set; }

        public AddWordDTO AddWordDTO { get; set; }

        public FilterWordsDTO FilterDTO { get; set; }

        public VocabularyModel(WordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public async Task OnGet()
        {
            Words = await _wordsRepository.GetWords();
        }

        public async Task<IActionResult> OnPostAddWord(AddWordDTO addWordDTO)
        {
            if (!ModelState.IsValid)
            {
                Words = await _wordsRepository.GetWords();
                return Page();
            }

            await _wordsRepository.AddWord(addWordDTO);

            return RedirectToPage("/Vocabulary");
        }

        public async Task<IActionResult> OnGetFilter(string lang, FilterWordsDTO filterWordsDTO)  // if the name is the same as the Page property,
                                                                                                  //  razor will asign whatever was passed to it!
        {
            if (!ModelState.IsValid)
            {
                Words = new List<Words>();
                return Page();
            }

            if (string.IsNullOrEmpty(filterWordsDTO.Word))
            {
                Words = await _wordsRepository.GetWords();
            }
            else
            {
                Words = lang == "g"
                    ? await _wordsRepository.FilterGermanWords(filterWordsDTO)
                    : await _wordsRepository.FilterSerbianWords(filterWordsDTO);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete([FromQuery][Required] int id)
        {
            if (ModelState.IsValid)
            {
                await _wordsRepository.Delete(id);
            }
            return RedirectToPage("/Vocabulary");
        }
    }
}
