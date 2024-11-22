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
    </style>

    <div id="game-container">
        <h1>Combate de Palabras</h1>
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
    </div>
    <canvas id="confetti-canvas"></canvas>

    <asp:HiddenField ID="selectedWordHiddenField" runat="server" />
    <asp:HiddenField ID="remainingAttemptsHiddenField" runat="server" />
    <asp:HiddenField ID="gameOverHiddenField" runat="server" />

    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js"></script>
    <script>
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

        function handleKeyPress(e) {
            const letter = e.key.toUpperCase();
            if (/^[A-ZÑ]$/.test(letter) && $('#<%= gameOverHiddenField.ClientID %>').val() !== 'true') {
                const $button = $(`.letter-btn:contains('${letter}')`);
                if (!$button.prop('disabled')) {
                    __doPostBack('CheckLetter', letter);
                }
            }
        }

        $(document).ready(function () {
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
