document.addEventListener('DOMContentLoaded', () => {
    // 1. Mobile Menu Toggle Setup
    const navbarContainer = document.querySelector('.navbar-container');
    const navLinks = document.querySelector('.nav-links');

    // Quick Search Form Validation
    const searchForm = document.querySelector('.search-card form');
    if (searchForm) {
        searchForm.addEventListener('submit', (e) => {
            const city = document.getElementById('city').value;
            const bloodGroup = document.getElementById('blood-group').value;

            if (!city && !bloodGroup) {
                e.preventDefault();
                alert('Meharbani karke Search karne ke liye kam az kam City ya Blood Group select karein.');
            }
        });
    }

    // Dynamic Active Link Highlighter
    const currentPath = window.location.pathname.split('/').pop();
    const links = document.querySelectorAll('.nav-links a');

    links.forEach(link => {
        const linkPath = link.getAttribute('href');
        if (linkPath === currentPath) {
            link.classList.add('active');
        } else if (currentPath === '' && linkPath === 'index.html') {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    });
});