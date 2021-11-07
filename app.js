const mobileMenu = document.querySelector('#mobile-menu')
const menuLink = document.querySelector('.navbar__menu')

//Mobile Menu
const mobileMenuAnimation = () => {
    mobileMenu.classList.toggle('is-active')
    menuLink.classList.toggle('active')
}

mobileMenu.addEventListener('click', mobileMenuAnimation)