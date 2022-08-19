//using Java.Lang;
using hangman_blazor_maui.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
//using Org.Apache.Http.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_blazor_maui.Pages
{
    public partial class Start
    {
        //[Inject]
        //private HttpClient httpClient { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public int WordLength { get; set; }

        [Parameter]
        public int IncorrectAttempts { get; set; }

        public string Word { get; set; }
        public string HangmanWord
        {
            get
            {
                var returnString = "";
                for (var i = 0; i < Word.Length; i++)
                {
                    if (RevealedIndexes.Contains(i))
                    {
                        returnString += Word[i];
                    }
                    else
                    {
                        returnString += "*";
                    }
                }
                return returnString;
            }
        }

        public List<int> RevealedIndexes { get; set; } = new() { 1 };

        public GuessALetterModel GuessedLetter { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await ConsoleLog("The word length is", WordLength);
            await ConsoleLog("The amount of incorrect guesses are", IncorrectAttempts);
            await GetWord();
        }

        public async Task GetWord()
        {
            await ConsoleLog("In GetWord");
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync($"https://random-word-api.herokuapp.com/word?length={WordLength}");
            await ConsoleLog(response);
            var word = (await response.Content.ReadAsStringAsync()).Split('"')[1];
            await ConsoleLog(word);
            Word = word;
        }



        public async Task ConsoleLog(params object[] args)
        {
            await JSRuntime.InvokeAsync<string>("console.log", args);
        }

        public async Task HandleValidSubmit(object e)
        {
            await ConsoleLog(e.GetType());
        }

    }
}
