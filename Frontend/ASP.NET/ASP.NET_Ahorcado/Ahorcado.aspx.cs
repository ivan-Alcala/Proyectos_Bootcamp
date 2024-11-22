﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Ahorcado
{
    public partial class _Default : Page
    {
        private static readonly string[] words = { "JAVASCRIPT", "PROGRAMA", "COMPUTADORA", "DESARROLLO", "APLICACION" };
        private const int MaxAttempts = 7;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitGame();
            }
            else
            {
                RestoreGameState();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string eventTarget = Request["__EVENTTARGET"];
            string eventArgument = Request["__EVENTARGUMENT"];

            if (eventTarget == "CheckLetter" && !string.IsNullOrEmpty(eventArgument))
            {
                CheckLetter(eventArgument);
            }
        }

        private void InitGame()
        {
            string selectedWord = words[new Random().Next(words.Length)];
            selectedWordHiddenField.Value = selectedWord;
            remainingAttemptsHiddenField.Value = MaxAttempts.ToString();
            gameOverHiddenField.Value = "false";

            // Limpiar las letras usadas en la sesión
            foreach (string key in Session.Keys.Cast<string>().Where(k => k.StartsWith("Letter_")).ToList())
            {
                Session.Remove(key);
            }

            ViewState["ClickedLetters"] = new List<string>();

            UpdateWordDisplay();
            UpdateHearts();
            CreateAlphabet();
            messageLiteral.Text = string.Empty;
            restartBtn.Style["display"] = "none";

            ClientScript.RegisterStartupScript(GetType(), "ResetCharacters", "resetCharacters();", true);
        }

        private void RestoreGameState()
        {
            UpdateWordDisplay();
            UpdateHearts();
            UpdateAlphabetButtons();
        }

        private void UpdateWordDisplay()
        {
            string selectedWord = selectedWordHiddenField.Value;
            string guessedWord = string.Join(" ", selectedWord.Select(c => Session[$"Letter_{c}"] != null && (bool)Session[$"Letter_{c}"] ? c.ToString() : "_"));
            wordDisplayLiteral.Text = guessedWord;
        }

        private void UpdateHearts()
        {
            int remainingAttempts = int.Parse(remainingAttemptsHiddenField.Value);
            heartsLiteral.Text = string.Join("", Enumerable.Repeat("❤️", remainingAttempts)) +
                                 string.Join("", Enumerable.Repeat("🖤", MaxAttempts - remainingAttempts));
        }

        private void CreateAlphabet()
        {
            string alphabet = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            List<char> alphabetList = alphabet.ToList();
            alphabetRepeater.DataSource = alphabetList;
            alphabetRepeater.DataBind();
        }

        public void CheckLetter(string letter)
        {
            if (gameOverHiddenField.Value == "true")
            {
                return;
            }

            var clickedLetters = (List<string>)ViewState["ClickedLetters"];
            if (!clickedLetters.Contains(letter))
            {
                clickedLetters.Add(letter);
                ViewState["ClickedLetters"] = clickedLetters;

                string selectedWord = selectedWordHiddenField.Value;
                int remainingAttempts = int.Parse(remainingAttemptsHiddenField.Value);

                if (selectedWord.Contains(letter))
                {
                    Session[$"Letter_{letter}"] = true;
                    messageLiteral.Text = "<div class='message-success'>¡Letra correcta!</div>";
                    ClientScript.RegisterStartupScript(GetType(), "AnimateAttack", $"animateAttack('#person', '#goblin');", true);
                }
                else
                {
                    Session[$"Letter_{letter}"] = false;
                    remainingAttempts--;
                    remainingAttemptsHiddenField.Value = remainingAttempts.ToString();
                    messageLiteral.Text = "<div class='message-error'>Letra incorrecta</div>";
                    ClientScript.RegisterStartupScript(GetType(), "AnimateAttack", $"animateAttack('#goblin', '#person');", true);
                }

                UpdateWordDisplay();
                UpdateHearts();
                UpdateAlphabetButtons();
                CheckGameStatus();
            }
        }

        protected void LetterBtn_Click(object sender, EventArgs e)
        {
            if (gameOverHiddenField.Value == "true")
            {
                return;
            }

            Button clickedButton = (Button)sender;
            CheckLetter(clickedButton.Text);
        }

        private void UpdateAlphabetButtons()
        {
            var clickedLetters = (List<string>)ViewState["ClickedLetters"];
            foreach (RepeaterItem item in alphabetRepeater.Items)
            {
                Button btn = (Button)item.FindControl("letterBtn");
                if (btn != null)
                {
                    bool isClicked = clickedLetters.Contains(btn.Text);
                    btn.Enabled = !isClicked && gameOverHiddenField.Value != "true";
                    btn.CssClass = isClicked ? "letter-btn btn btn-secondary" : "letter-btn btn btn-outline-primary";
                }
            }
        }

        private void CheckGameStatus()
        {
            string selectedWord = selectedWordHiddenField.Value;
            string guessedWord = string.Join("", selectedWord.Select(c => Session[$"Letter_{c}"] != null ? c.ToString() : "_"));
            int remainingAttempts = int.Parse(remainingAttemptsHiddenField.Value);

            if (guessedWord == selectedWord)
            {
                messageLiteral.Text = "<div class='message-win'>¡Felicidades! Has ganado.</div>";
                EndGame(true);
            }
            else if (remainingAttempts == 0)
            {
                messageLiteral.Text = $"<div class='message-lose'>Has perdido. La palabra era: {selectedWord}</div>";
                EndGame(false);
            }
        }

        private void EndGame(bool isWin)
        {
            gameOverHiddenField.Value = "true";

            foreach (RepeaterItem item in alphabetRepeater.Items)
            {
                Button btn = (Button)item.FindControl("letterBtn");
                if (btn != null)
                {
                    btn.Enabled = false;
                }
            }

            restartBtn.Style["display"] = "inline-block";

            if (isWin)
            {
                ClientScript.RegisterStartupScript(GetType(), "WinAnimation", "$('#goblin').text('💀'); launchConfetti();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "LoseAnimation", "$('#person').text('💀'); createFireExplosion();", true);
            }
        }

        protected void RestartBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            InitGame();
        }
    }
}
