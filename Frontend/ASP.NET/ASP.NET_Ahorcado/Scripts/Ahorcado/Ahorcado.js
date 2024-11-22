function animateAttack(attacker) {
    const $attacker = $(attacker);
    const originalPosition = attacker === '#person' ? '0px' : '300px';
    const attackPosition = attacker === '#person' ? '200px' : '100px';

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
    return true;
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
        const fireColors = ['#ff6600', '#ff9933', '#ffcc00', '#ff3300', '#ff0000'];

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

    $('body').css('background-color', '#ff6600');
    setTimeout(() => {
        $('body').css('background-color', '#f0f0f0');
    }, 100);
}

function endGame(isWin) {
    if (isWin) {
        launchConfetti();
    } else {
        createFireExplosion();
    }
}