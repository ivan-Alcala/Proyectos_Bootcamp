<%@ Page Title="Combate de Palabras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ahorcado.aspx.cs" Inherits="ASP.NET_Ahorcado._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f0f0f0;
            overflow: hidden;
        }
        #game-container {
            text-align: center;
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            position: relative;
            z-index: 1;
        }
        #word-display {
            font-size: 2em;
            margin-bottom: 20px;
        }
        #alphabet {
            margin-bottom: 20px;
        }
        .letter-btn {
            margin: 2px;
            padding: 5px 10px;
            font-size: 1em;
        }
        #hearts {
            font-size: 2em;
            margin-bottom: 10px;
        }
        #message {
            margin-top: 10px;
            font-weight: bold;
        }
        .message-success {
            color: #155724;
            background-color: #d4edda;
            border-color: #c3e6cb;
            padding: 10px;
            border-radius: 5px;
            margin-top: 10px;
        }
        .message-error {
            color: #721c24;
            background-color: #f8d7da;
            border-color: #f5c6cb;
            padding: 10px;
            border-radius: 5px;
            margin-top: 10px;
        }
        .message-win {
            color: #004085;
            background-color: #cce5ff;
            border-color: #b8daff;
            padding: 10px;
            border-radius: 5px;
            margin-top: 10px;
        }
        .message-lose {
            color: #856404;
            background-color: #fff3cd;
            border-color: #ffeeba;
            padding: 10px;
            border-radius: 5px;
            margin-top: 10px;
        }
        #battle-scene {
            width: 300px;
            height: 100px;
            margin: 0 auto 20px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            position: relative;
        }
        .character {
            font-size: 4em;
            position: absolute;
            transition: all 0.5s ease;
        }
        #person {
            left: 0;
        }
        #goblin {
            right: 0;
        }
        @keyframes shake {
            0% { transform: translate(1px, 1px) rotate(0deg); }
            10% { transform: translate(-1px, -2px) rotate(-1deg); }
            20% { transform: translate(-3px, 0px) rotate(1deg); }
            30% { transform: translate(3px, 2px) rotate(0deg); }
            40% { transform: translate(1px, -1px) rotate(1deg); }
            50% { transform: translate(-1px, 2px) rotate(-1deg); }
            60% { transform: translate(-3px, 1px) rotate(0deg); }
            70% { transform: translate(3px, 1px) rotate(-1deg); }
            80% { transform: translate(-1px, -1px) rotate(1deg); }
            90% { transform: translate(1px, 2px) rotate(0deg); }
            100% { transform: translate(1px, -2px) rotate(-1deg); }
        }
        .shake {
            animation: shake 0.5s;
            animation-iteration-count: 1;
        }
        #confetti-canvas {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            pointer-events: none;
            z-index: 2;
        }
        #timer {
            font-size: 1.5em;
            margin-bottom: 10px;
            font-weight: bold;
        }
        .circular-menu {
          position: fixed;
          bottom: 1em;
          right: 1em;
        }

        .circular-menu .floating-btn {
          display: block;
          width: 3.5em;
          height: 3.5em;
          border-radius: 50%;
          background-color: hsl(4, 98%, 60%);
          box-shadow: 0 2px 5px 0 hsla(0, 0%, 0%, .26);  
          color: hsl(0, 0%, 100%);
          text-align: center;
          line-height: 3.9;
          cursor: pointer;
          outline: 0;
        }

        .circular-menu.active .floating-btn {
          box-shadow: inset 0 0 3px hsla(0, 0%, 0%, .3);
        }

        .circular-menu .floating-btn:active {
          box-shadow: 0 4px 8px 0 hsla(0, 0%, 0%, .4);
        }

        .circular-menu .floating-btn i {
          font-size: 1.3em;
          transition: transform .2s;  
        }

        .circular-menu.active .floating-btn i {
          transform: rotate(-45deg);
        }

        .circular-menu:after {
          display: block;
          content: ' ';
          width: 3.5em;
          height: 3.5em;
          border-radius: 50%;
          position: absolute;
          top: 0;
          right: 0;
          z-index: -2;
          background-color: hsl(4, 98%, 60%);
          transition: all .3s ease;
        }

        .circular-menu.active:after {
          transform: scale3d(5.5, 5.5, 1);
          transition-timing-function: cubic-bezier(.68, 1.55, .265, 1);
        }

        .circular-menu .items-wrapper {
          padding: 0;
          margin: 0;
        }

        .circular-menu .menu-item {
          position: absolute;
          top: .2em;
          right: .2em;
          z-index: -1;
          display: block;
          text-decoration: none;
          color: hsl(0, 0%, 100%);
          font-size: 1em;
          width: 3em;
          height: 3em;
          border-radius: 50%;
          text-align: center;
          line-height: 3;
          background-color: hsla(0,0%,0%,.1);
          transition: transform .3s ease, background .2s ease;
        }

        .circular-menu .menu-item:hover {
          background-color: hsla(0,0%,0%,.3);
        }

        .circular-menu.active .menu-item {
          transition-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1.275);
        }

        .circular-menu.active .menu-item:nth-child(1) {
          transform: translate3d(1em,-7em,0);
        }

        .circular-menu.active .menu-item:nth-child(2) {
          transform: translate3d(-3.5em,-6.3em,0);
        }

        .circular-menu.active .menu-item:nth-child(3) {
          transform: translate3d(-6.5em,-3.2em,0);
        }

        .circular-menu.active .menu-item:nth-child(4) {
          transform: translate3d(-7em,1em,0);
        }

        /**
         * The other theme for this menu
         */

        .circular-menu.circular-menu-left {
          right: auto; 
          left: 1em;
        }

        .circular-menu.circular-menu-left .floating-btn {
          background-color: hsl(217, 89%, 61%);
        }

        .circular-menu.circular-menu-left:after {
          background-color: hsl(217, 89%, 61%);
        }

        .circular-menu.circular-menu-left.active .floating-btn i {
          transform: rotate(90deg);
        }

        .circular-menu.circular-menu-left.active .menu-item:nth-child(1) {
          transform: translate3d(-1em,-7em,0);
        }

        .circular-menu.circular-menu-left.active .menu-item:nth-child(2) {
          transform: translate3d(3.5em,-6.3em,0);
        }

        .circular-menu.circular-menu-left.active .menu-item:nth-child(3) {
          transform: translate3d(6.5em,-3.2em,0);
        }

        .circular-menu.circular-menu-left.active .menu-item:nth-child(4) {
          transform: translate3d(7em,1em,0);
        }

        .modal {
            display: none;
            position: fixed;
            z-index: 1001;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgba(0,0,0,0.4);
        }

        .modal-content {
            background-color: #fefefe;
            margin: 15% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            max-width: 500px;
        }

        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
            cursor: pointer;
        }

        .close:hover,
        .close:focus {
            color: black;
            text-decoration: none;
            cursor: pointer;
        }
    </style>

    <div id="game-container">
        <h1>Combate de Palabras</h1>
        <div id="timer">Tiempo restante: <span id="time-left"></span></div>
        <div id="battle-scene">
            <div id="person" class="character">🧙</div>
            <div id="goblin" class="character">👺</div>
        </div>
        <div id="hearts">
            <asp:Literal ID="heartsLiteral" runat="server" />
        </div>
        <div id="word-display">
            <asp:Literal ID="wordDisplayLiteral" runat="server" />
        </div>
        <div id="alphabet">
            <asp:Repeater ID="alphabetRepeater" runat="server">
                <ItemTemplate>
                    <asp:Button ID="letterBtn" runat="server" 
                        Text='<%# Container.DataItem %>'
                        CommandArgument='<%# Container.DataItem %>'
                        CssClass="letter-btn btn btn-outline-primary"
                        OnClick="LetterBtn_Click" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="message">
            <asp:Literal ID="messageLiteral" runat="server" />
        </div>
        <asp:Button ID="restartBtn" runat="server" Text="Reiniciar Juego" CssClass="btn btn-primary" OnClick="RestartBtn_Click" style="display: none;" />
        
        <div id="circularMenu1" class="circular-menu">
            <a class="floating-btn" onclick="document.getElementById('circularMenu1').classList.toggle('active');">☰</a>
            <menu class="items-wrapper">
                <a data-action="character" class="menu-item" title="Cambiar Personaje">👤</a>
                <a data-action="time" class="menu-item" title="Cambiar Tiempo">⏱️</a>
                <a data-action="instructions" class="menu-item" title="Instrucciones">❓</a>
                <a data-action="attempts" class="menu-item" title="Cambiar Intentos">🎯</a>
            </menu>
        </div>

        <div id="characterModal" class="modal">
            <div class="modal-content">
                <span class="close">&times;</span>
                <h2>Seleccionar Personaje</h2>
                <div id="characterOptions">
                    <button class="character-option" data-character="🧙">🧙</button>
                    <button class="character-option" data-character="🦸">🦸</button>
                    <button class="character-option" data-character="🧝">🧝</button>
                    <button class="character-option" data-character="🧚">🧚</button>
                </div>
            </div>
        </div>

        <div id="timeModal" class="modal">
            <div class="modal-content">
                <span class="close">&times;</span>
                <h2>Cambiar Tiempo</h2>
                <asp:DropDownList ID="timeDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TimeDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="60">1 minuto</asp:ListItem>
                    <asp:ListItem Value="180">3 minutos</asp:ListItem>
                    <asp:ListItem Value="300">5 minutos</asp:ListItem>
                    <asp:ListItem Value="-1">Infinito</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div id="instructionsModal" class="modal">
            <div class="modal-content">
                <span class="close">&times;</span>
                <h2>Instrucciones</h2>
                <p>1. Adivina la palabra oculta letra por letra.</p>
                <p>2. Cada letra incorrecta reduce tus intentos.</p>
                <p>3. Gana adivinando la palabra antes de quedarte sin intentos o que se acabe el tiempo.</p>
            </div>
        </div>

        <div id="attemptsModal" class="modal">
            <div class="modal-content">
                <span class="close">&times;</span>
                <h2>Cambiar Intentos</h2>
                <asp:DropDownList ID="attemptsDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AttemptsDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="3">3 intentos</asp:ListItem>
                    <asp:ListItem Value="5">5 intentos</asp:ListItem>
                    <asp:ListItem Value="7">7 intentos</asp:ListItem>
                    <asp:ListItem Value="10">10 intentos</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <canvas id="confetti-canvas"></canvas>

    <asp:HiddenField ID="selectedWordHiddenField" runat="server" />
    <asp:HiddenField ID="remainingAttemptsHiddenField" runat="server" />
    <asp:HiddenField ID="gameOverHiddenField" runat="server" />
    <asp:HiddenField ID="timeLeftHiddenField" runat="server" />

    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js"></script>
    <script>
        let timer;
        let selectedCharacter = '🧙';

        function startTimer(duration) {
            clearInterval(timer);
            if (duration === -1) {
                document.getElementById('time-left').textContent = 'Infinito';
                return;
            }

            let timeLeft = duration;
            updateTimerDisplay(timeLeft);

            timer = setInterval(function () {
                timeLeft--;
                updateTimerDisplay(timeLeft);

                if (timeLeft <= 0) {
                    clearInterval(timer);
                    __doPostBack('TimeUp', '');
                }
            }, 1000);
        }

        function updateTimerDisplay(timeLeft) {
            const minutes = Math.floor(timeLeft / 60);
            const seconds = timeLeft % 60;
            $('#time-left').text(minutes.toString().padStart(2, '0') + ':' + seconds.toString().padStart(2, '0'));
            $('#<%= timeLeftHiddenField.ClientID %>').val(timeLeft);
        }

        function stopTimer() {
            clearInterval(timer);
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
                    }, 500, function() {
                        // Solo restaurar el personaje si el juego no está terminado
                        if (attacker === '#person' && $('#<%= gameOverHiddenField.ClientID %>').val() !== 'true') {
                            document.getElementById('person').textContent = selectedCharacter;
                        }
                    });
                }, 500);
            });
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
            // Solo resetear los personajes si el juego no está terminado
            if ($('#<%= gameOverHiddenField.ClientID %>').val() !== 'true') {
                document.getElementById('person').textContent = selectedCharacter;
                document.getElementById('goblin').textContent = '👺';
            }
            document.getElementById('person').style.left = '0';
            document.getElementById('person').style.right = '';
            document.getElementById('goblin').style.right = '0';
            document.getElementById('goblin').style.left = '';
        }

        function handleKeyPress(e) {
            const letter = e.key.toUpperCase();
            if (/^[A-ZÑ]$/.test(letter) && $('#<%= gameOverHiddenField.ClientID %>').val() !== 'true') {
                const $button = $(`.letter-btn:contains('${letter}')`);
                if (!$button.prop('disabled')) {
                    __doPostBack('CheckLetter', letter);
                }
            }
        }

        function showModal(modalId) {
            console.log("asd");
            document.getElementById(modalId).style.display = "block";
        }

        function closeModal(modalId) {
            document.getElementById(modalId).style.display = "none";
        }

        document.querySelectorAll('.menu-item').forEach(item => {
            item.addEventListener('click', function() {
                const action = this.getAttribute('data-action');
                showModal(action + 'Modal');
            });
        });

        document.querySelectorAll('.close').forEach(closeBtn => {
            closeBtn.addEventListener('click', function() {
                closeModal(this.closest('.modal').id);
            });
        });

        document.querySelectorAll('.character-option').forEach(option => {
            option.addEventListener('click', function() {
                selectedCharacter = this.getAttribute('data-character');
                document.getElementById('person').textContent = selectedCharacter;
                closeModal('characterModal');
                // Guardar el personaje seleccionado en el almacenamiento local
                localStorage.setItem('selectedCharacter', selectedCharacter);
            });
        });

        window.onclick = function(event) {
            if (event.target.classList.contains('modal')) {
                closeModal(event.target.id);
            }
        }

        function updateGameDuration(duration) {
            if (duration === -1) {
                clearInterval(timer);
                document.getElementById('time-left').textContent = 'Infinito';
            } else {
                startTimer(duration);
            }
        }

        // Función para restaurar el personaje seleccionado
        function restoreSelectedCharacter() {
            const storedCharacter = localStorage.getItem('selectedCharacter');
            if (storedCharacter) {
                selectedCharacter = storedCharacter;
                document.getElementById('person').textContent = selectedCharacter;
            }
        }

        // Llamar a esta función cuando se inicie o reinicie el juego
        $(document).ready(function () {
            restoreSelectedCharacter();
            resetCharacters();

            const initialTime = parseInt($('#<%= timeLeftHiddenField.ClientID %>').val());
            if (initialTime > 0) {
                startTimer(initialTime);
            }

            $(document).on('click', '.letter-btn', function (e) {
                if (!$(this).prop('disabled') && $('#<%= gameOverHiddenField.ClientID %>').val() !== 'true') {
                    __doPostBack($(this).attr('name'), $(this).text());
                }
                e.preventDefault();
            });

            $(document).on('keydown', handleKeyPress);
        });
    </script>
</asp:Content>

