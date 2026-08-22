/* ==========================================================================
   BloodConnect.pk — Admin Portal shared behaviour
   One universal modal system used by every admin page:
     - openModal(id) / closeModal(id)
     - click on the backdrop closes the modal
     - Escape key closes the topmost open modal
     - body scroll is locked while a modal is open
   This replaces the old per-page toggleModal()/openModal() split that
   caused inconsistent (sometimes non-opening) modals across pages.
   ========================================================================== */

(function () {
    function lockScroll(lock) {
        document.documentElement.style.overflow = lock ? 'hidden' : '';
    }

    window.openModal = function (id) {
        const el = document.getElementById(id);
        if (!el) return;
        el.classList.remove('hidden');
        requestAnimationFrame(() => el.classList.add('is-open'));
        lockScroll(true);
    };

    window.closeModal = function (id) {
        const el = document.getElementById(id);
        if (!el) return;
        el.classList.add('hidden');
        el.classList.remove('is-open');
        if (!document.querySelector('[id$="-modal"]:not(.hidden)')) {
            lockScroll(false);
        }
    };

    document.addEventListener('DOMContentLoaded', () => {
        // Close modal when clicking the dark backdrop itself (not its inner panel)
        document.querySelectorAll('[id$="-modal"]').forEach((modal) => {
            modal.addEventListener('click', (e) => {
                if (e.target === modal) closeModal(modal.id);
            });
        });

        // Escape closes the last visible modal
        document.addEventListener('keydown', (e) => {
            if (e.key !== 'Escape') return;
            const openModals = document.querySelectorAll('[id$="-modal"]:not(.hidden)');
            if (openModals.length) closeModal(openModals[openModals.length - 1].id);
        });

        // Sidebar toggle (shared markup: #sidebar-toggle-btn, #sidebar, icons)
        const sidebar = document.getElementById('sidebar');
        const toggleBtn = document.getElementById('sidebar-toggle-btn');
        const backdrop = document.getElementById('sidebar-backdrop');
        const hamburgerIcon = document.getElementById('hamburger-icon');
        const closeIcon = document.getElementById('close-icon');

        function toggleSidebar() {
            if (!sidebar) return;
            sidebar.classList.toggle('-translate-x-full');
            backdrop?.classList.toggle('hidden');
            hamburgerIcon?.classList.toggle('hidden');
            closeIcon?.classList.toggle('hidden');
        }

        toggleBtn?.addEventListener('click', toggleSidebar);
        backdrop?.addEventListener('click', toggleSidebar);

        // Highlight the current page in the sidebar automatically
        const currentPage = window.location.pathname.split('/').pop();
        document.querySelectorAll('#sidebar nav a[href]').forEach((link) => {
            if (link.getAttribute('href') === currentPage) {
                link.classList.add('nav-link-active');
            }
        });
    });
})();
