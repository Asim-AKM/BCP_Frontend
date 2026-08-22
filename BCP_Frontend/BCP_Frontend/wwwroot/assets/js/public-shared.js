/* ==========================================================================
   BloodConnect.pk — Public site shared behaviour
   Mobile nav, scroll-reveal, animated counters, and a lightweight
   pointer-based 3D tilt for case/story cards.
   ========================================================================== */

(function () {
    document.addEventListener('DOMContentLoaded', () => {

        /* Mobile nav drawer */
        const menuBtn = document.getElementById('menu-btn');
        const mobileMenu = document.getElementById('mobile-menu');
        const menuIcon = document.getElementById('menu-icon');
        const closeIcon = document.getElementById('close-icon');

        menuBtn?.addEventListener('click', () => {
            mobileMenu.classList.toggle('hidden');
            menuIcon.classList.toggle('hidden');
            closeIcon.classList.toggle('hidden');
        });

        /* Scroll reveal */
        const revealEls = document.querySelectorAll('.reveal');
        if ('IntersectionObserver' in window && revealEls.length) {
            const io = new IntersectionObserver((entries) => {
                entries.forEach((entry) => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('is-visible');
                        io.unobserve(entry.target);
                    }
                });
            }, { threshold: 0.15, rootMargin: '0px 0px -40px 0px' });
            revealEls.forEach((el) => io.observe(el));
        } else {
            revealEls.forEach((el) => el.classList.add('is-visible'));
        }

        /* Animated counters: <span data-count-to="12450" data-suffix="+"> */
        const counters = document.querySelectorAll('[data-count-to]');
        if ('IntersectionObserver' in window && counters.length) {
            const countIO = new IntersectionObserver((entries) => {
                entries.forEach((entry) => {
                    if (!entry.isIntersecting) return;
                    const el = entry.target;
                    countIO.unobserve(el);
                    const target = parseFloat(el.getAttribute('data-count-to'));
                    const suffix = el.getAttribute('data-suffix') || '';
                    const duration = 1400;
                    const start = performance.now();
                    function tick(now) {
                        const progress = Math.min((now - start) / duration, 1);
                        const eased = 1 - Math.pow(1 - progress, 3);
                        const value = Math.round(target * eased);
                        el.textContent = value.toLocaleString() + suffix;
                        if (progress < 1) requestAnimationFrame(tick);
                    }
                    requestAnimationFrame(tick);
                });
            }, { threshold: 0.5 });
            counters.forEach((el) => countIO.observe(el));
        }

        /* Subtle 3D tilt on pointer for .tilt-card elements */
        const tiltCards = document.querySelectorAll('.tilt-card');
        tiltCards.forEach((card) => {
            card.addEventListener('mousemove', (e) => {
                const rect = card.getBoundingClientRect();
                const x = (e.clientX - rect.left) / rect.width - 0.5;
                const y = (e.clientY - rect.top) / rect.height - 0.5;
                card.style.transform = `perspective(700px) rotateY(${x * 6}deg) rotateX(${-y * 6}deg) translateY(-4px)`;
            });
            card.addEventListener('mouseleave', () => {
                card.style.transform = 'perspective(700px) rotateY(0deg) rotateX(0deg) translateY(0)';
            });
        });
    });
})();
