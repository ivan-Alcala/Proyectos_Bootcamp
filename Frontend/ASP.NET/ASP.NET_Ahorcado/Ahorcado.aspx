<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ahorcado.aspx.cs" Inherits="ASP.NET_Ahorcado._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div id="game-container">
            <h1>Combate de Palabras</h1>
            <div id="battle-scene">
                <div id="person" class="character">🧙</div>
                <div id="goblin" class="character">👺</div>
            </div>
            <div id="hearts">❤️❤️❤️❤️❤️❤️❤️</div>
            <div id="word-display"></div>
            <div id="alphabet"></div>
            <div id="message"></div>
            <button id="restart-btn" class="btn btn-primary" style="display: none;">Reiniciar Juego</button>
        </div>
        <canvas id="confetti-canvas"></canvas>
                       <script>
                           $(document).ready(function () {
                               const words = ['JAVASCRIPT', 'PROGRAMA', 'COMPUTADORA', 'DESARROLLO', 'APLICACION'];
                               let selectedWord = '';
                               let guessedWord = [];
                               let remainingAttempts = 7;
                               let usedLetters = new Set();

                               function initGame() {
                                   selectedWord = words[Math.floor(Math.random() * words.length)];
                                   guessedWord = Array(selectedWord.length).fill('_');
                                   remainingAttempts = 7;
                                   usedLetters.clear();
                                   updateDisplay();
                                   createAlphabet();
                                   $('#restart-btn').hide();
                                   $('#message').text('');
                                   $('#hearts').html('❤️'.repeat(7));
                                   resetCharacters();
                                   $('.letter-btn').prop('disabled', false).removeClass('btn-secondary').addClass('btn-outline-primary');
                               }

                               function updateDisplay() {
                                   $('#word-display').text(guessedWord.join(' '));
                               }

                               function createAlphabet() {
                                   const alphabet = 'ABCDEFGHIJKLMNÑOPQRSTUVWXYZ';
                                   $('#alphabet').empty();
                                   for (let letter of alphabet) {
                                       $('<button>')
                                           .addClass('letter-btn btn btn-outline-primary')
                                           .text(letter)
                                           .click(function () {
                                               checkLetter(letter);
                                           })
                                           .appendTo('#alphabet');
                                   }
                               }

                               function checkLetter(letter) {
                                   if (usedLetters.has(letter)) return;

                                   usedLetters.add(letter);
                                   let found = false;
                                   for (let i = 0; i < selectedWord.length; i++) {
                                       if (selectedWord[i] === letter) {
                                           guessedWord[i] = letter;
                                           found = true;
                                       }
                                   }

                                   if (found) {
                                       $('#message').text('¡Letra correcta!').css('color', 'green');
                                       animateAttack('#person', '#goblin');
                                   } else {
                                       remainingAttempts--;
                                       $('#hearts').html('❤️'.repeat(remainingAttempts) + '🖤'.repeat(7 - remainingAttempts));
                                       $('#message').text('Letra incorrecta').css('color', 'red');
                                       animateAttack('#goblin', '#person');
                                   }

                                   updateDisplay();
                                   updateAlphabetButtons();
                                   checkGameStatus();
                               }

                               function animateAttack(attacker, target) {
                                   const $attacker = $(attacker);
                                   const $target = $(target);
                                   const originalPosition = attacker === '#person' ? '-200px' : '-200px';
                                   const attackPosition = attacker === '#person' ? '200px' : '200px';

                                   $attacker.animate({
                                       left: attacker === '#person' ? attackPosition : '',
                                       right: attacker === '#goblin' ? attackPosition : ''
                                   }, 500, function () {
                                       $('#battle-scene').addClass('shake');
                                       setTimeout(() => {
                                           $('#battle-scene').removeClass('shake');
                                           $attacker.animate({
                                               left: attacker === '#person' ? originalPosition : '',
                                               right: attacker === '#goblin' ? originalPosition : ''
                                           }, 500);
                                       }, 500);
                                   });
                               }

                               function updateAlphabetButtons() {
                                   $('.letter-btn').each(function () {
                                       if (usedLetters.has($(this).text())) {
                                           $(this).prop('disabled', true).removeClass('btn-outline-primary').addClass('btn-secondary');
                                       }
                                   });
                               }

                               function checkGameStatus() {
                                   if (guessedWord.join('') === selectedWord) {
                                       $('#message').text('¡Felicidades! Has ganado.').css('color', 'green');
                                       $('#goblin').text('💀');
                                       endGame(true);
                                   } else if (remainingAttempts === 0) {
                                       $('#message').text(`Has perdido. La palabra era: ${selectedWord}`).css('color', 'red');
                                       $('#person').text('💀');
                                       endGame(false);
                                   }
                               }

                               function endGame(isWin) {
                                   $('.letter-btn').prop('disabled', true);
                                   $('#restart-btn').show();
                                   $(document).off('keydown');

                                   if (isWin) {
                                       launchConfetti();
                                   } else {
                                       createFireExplosion();
                                   }
                               }

                               function launchConfetti() {
                                   const duration = 5 * 1000;
                                   const animationEnd = Date.now() + duration;
                                   const defaults = { startVelocity: 30, spread: 360, ticks: 60, zIndex: 0 };

                                   function randomInRange(min, max) {
                                       return Math.random() * (max - min) + min;
                                   }

                                   const interval = setInterval(function () {
                                       const timeLeft = animationEnd - Date.now();

                                       if (timeLeft <= 0) {
                                           return clearInterval(interval);
                                       }

                                       const particleCount = 50 * (timeLeft / duration);
                                       confetti(Object.assign({}, defaults, { particleCount, origin: { x: randomInRange(0.1, 0.3), y: Math.random() - 0.2 } }));
                                       confetti(Object.assign({}, defaults, { particleCount, origin: { x: randomInRange(0.7, 0.9), y: Math.random() - 0.2 } }));
                                   }, 250);
                               }

                               function createFireExplosion() {
                                   const duration = 3 * 1000;
                                   const animationEnd = Date.now() + duration;
                                   const defaults = { startVelocity: 45, spread: 360, ticks: 100, zIndex: 0 };

                                   function randomInRange(min, max) {
                                       return Math.random() * (max - min) + min;
                                   }

                                   const interval = setInterval(function () {
                                       const timeLeft = animationEnd - Date.now();

                                       if (timeLeft <= 0) {
                                           return clearInterval(interval);
                                       }

                                       const particleCount = 200 * (timeLeft / duration);

                                       // Fire colors
                                       const fireColors = ['#ff6600', '#ff9933', '#ffcc00', '#ff3300', '#ff0000'];

                                       // Create multiple origins for a more explosive effect
                                       for (let i = 0; i < 5; i++) {
                                           confetti(Object.assign({}, defaults, {
                                               particleCount: particleCount / 5,
                                               origin: {
                                                   x: randomInRange(0.3, 0.7),
                                                   y: randomInRange(0.4, 0.6)
                                               },
                                               colors: fireColors,
                                               gravity: 1,
                                               scalar: randomInRange(0.8, 1.2),
                                               drift: randomInRange(-1, 1)
                                           }));
                                       }
                                   }, 25);

                                   // Add a flash effect
                                   $('body').css('background-color', '#ff6600');
                                   setTimeout(() => {
                                       $('body').css('background-color', '#f0f0f0');
                                   }, 100);
                               }

                               function resetCharacters() {
                                   $('#person').text('🧙').css({ 'left': '0', 'right': '' });
                                   $('#goblin').text('👺').css({ 'right': '0', 'left': '' });
                               }

                               $('#restart-btn').click(initGame);

                               $(document).on('keydown', function (e) {
                                   const letter = e.key.toUpperCase();
                                   if (/^[A-ZÑ]$/.test(letter)) {
                                       checkLetter(letter);
                                   }
                               });

                               initGame();
                           });
                       </script>
    </main>

</asp:Content>
