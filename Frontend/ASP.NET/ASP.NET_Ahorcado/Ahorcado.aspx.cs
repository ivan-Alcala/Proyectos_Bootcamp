using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Ahorcado
{
    public partial class _Default : Page
    {
        private static readonly string[] words = { "JAVASCRIPT", "PROGRAMA", "COMPUTADORA", "DESARROLLO", "APLICACION" };
        private const int DefaultGameDuration = 180; // 3 minutos
        private const int DefaultMaxAttempts = 7;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Solo inicializamos los valores por defecto si no existen en la sesión
                if (Session["GameDuration"] == null)
                {
                    Session["GameDuration"] = DefaultGameDuration;
                }
                if (Session["MaxAttempts"] == null)
                {
                    Session["MaxAttempts"] = DefaultMaxAttempts;
                }

                InitGame();
            }
            else
            {
                RestoreGameState();
            }

            // Actualizamos los dropdowns para reflejar los valores actuales
            if (!IsPostBack)
            {
                timeDropDown.SelectedValue = Session["GameDuration"].ToString();
                attemptsDropDown.SelectedValue = Session["MaxAttempts"].ToString();
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
            else if (eventTarget == "TimeUp")
            {
                EndGame(false, "¡Se acabó el tiempo!");
            }
        }

        private void InitGame()
        {
            string selectedWord = words[new Random().Next(words.Length)];
            selectedWordHiddenField.Value = selectedWord;

            // Usar los valores de la sesión en lugar de los valores por defecto
            int maxAttempts = (int)Session["MaxAttempts"];
            remainingAttemptsHiddenField.Value = maxAttempts.ToString();

            int gameDuration = (int)Session["GameDuration"];
            timeLeftHiddenField.Value = gameDuration.ToString();

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

            // Registrar scripts para inicializar el juego
            ClientScript.RegisterStartupScript(GetType(), "StartTimer", $"startTimer({gameDuration});", true);
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
            int maxAttempts = Session["MaxAttempts"] != null ? (int)Session["MaxAttempts"] : DefaultMaxAttempts;
            heartsLiteral.Text = string.Join("", Enumerable.Repeat("❤️", remainingAttempts)) +
                                 string.Join("", Enumerable.Repeat("🖤", maxAttempts - remainingAttempts));
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
                EndGame(true, "<div class='message-win'>¡Felicidades! Has ganado.</div>");
            }
            else if (remainingAttempts == 0)
            {
                EndGame(false, $"<div class='message-lose'>Has perdido. La palabra era: {selectedWord}</div>");
            }
        }

        private void EndGame(bool isWin, string message)
        {
            gameOverHiddenField.Value = "true";
            messageLiteral.Text = message;

            foreach (RepeaterItem item in alphabetRepeater.Items)
            {
                Button btn = (Button)item.FindControl("letterBtn");
                if (btn != null)
                {
                    btn.Enabled = false;
                }
            }

            restartBtn.Style["display"] = "inline-block";
            ClientScript.RegisterStartupScript(GetType(), "StopTimer", "stopTimer();", true);

            if (isWin)
            {
                ClientScript.RegisterStartupScript(GetType(), "WinAnimation", "$('#goblin').text('💀'); launchConfetti();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "LoseAnimation", "$('#person').text('💀');", true);
                ClientScript.RegisterStartupScript(GetType(), "FireAnimation", "createFireExplosion();", true);
            }
        }

        protected void RestartBtn_Click(object sender, EventArgs e)
        {
            // Mantener solo los valores de configuración en la sesión
            var gameDuration = Session["GameDuration"];
            var maxAttempts = Session["MaxAttempts"];

            Session.Clear();

            // Restaurar los valores de configuración
            Session["GameDuration"] = gameDuration;
            Session["MaxAttempts"] = maxAttempts;

            InitGame();
        }

        protected void TimeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDuration = int.Parse(timeDropDown.SelectedValue);
            Session["GameDuration"] = selectedDuration;
            timeLeftHiddenField.Value = selectedDuration.ToString();
            ClientScript.RegisterStartupScript(GetType(), "UpdateTimer", $"updateGameDuration({selectedDuration});", true);
        }

        protected void AttemptsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedAttempts = int.Parse(attemptsDropDown.SelectedValue);
            Session["MaxAttempts"] = selectedAttempts;
            remainingAttemptsHiddenField.Value = selectedAttempts.ToString();
            UpdateHearts();
        }
    }
}

