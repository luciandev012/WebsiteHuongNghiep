
window.addEventListener('DOMContentLoaded', event => {

    
    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 74,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

    // Activate SimpleLightbox plugin for portfolio items
    new SimpleLightbox({
        elements: '#portfolio a.portfolio-box'
    });
    var input = document.querySelector("#number");
    window.intlTelInput(input, {
        // any initialisation options go here
        separateDialCode: true,
    });
    var input = document.querySelector("#number2");
    window.intlTelInput(input, {
        // any initialisation options go here
        separateDialCode: true,
    });
    
    $('#password, #confirmPassword').on('keyup', () => {
        if ($('#password').val() == $('#confirmPassword').val()) {
            $('#passwordMessage').removeClass('text-success');
            $('#passwordMessage').html('Mật khẩu khớp').addClass('text-danger');
        } else {
            $('#passwordMessage').removeClass('text-danger');
            $('#passwordMessage').html('Mật khẩu không khớp').addClass('text-success');
        }
    });
});
const toggleBtn = document.getElementById("login_signup"),
    signup_form = document.getElementById("sign-up"),
    signin_form = document.getElementById("sign-in"),
    reminder = document.getElementById("reminder"),
    titleHeader = document.getElementById("title-header");

let isLoginForm = false;
function changeState() {
    if (!isLoginForm) {
        signin_form.classList.remove("show");
        signin_form.classList.add("hide");
        signup_form.classList.add("show");
        signup_form.style.position = "relative";
        reminder.innerHTML = "Bạn đã có tài khoản?";
        this.innerHTML = "Đăng nhập ngay";
        titleHeader.innerHTML = "Đăng ký";
    } else {
        signup_form.classList.remove("show");

        signin_form.classList.remove("hide");
        signin_form.classList.add("show");
        signup_form.style.position = "absolute";
        reminder.innerHTML = "Bạn chưa có tài khoản?";
        titleHeader.innerHTML = "Đăng nhập";
        this.innerHTML = "Đăng ký ngay";
    }
    isLoginForm = !isLoginForm;
}

toggleBtn.addEventListener("click", changeState);

function validateRegisterForm() {

    //validate phone number
    let phoneNumber = document.getElementById("phoneNumber").value;
    let phonePattern = /0[0-9]{9}/;
    if (!phonePattern.test(phoneNumber) || phoneNumber.length > 10) {
        $('#msgAlert').html('Số điện thoại không đúng định dạng').css('display', 'block');
        setTimeout(() => {
            $("#msgAlert").fadeOut('slow');
        }, 2000);
        return false;
    }

    //check password and confirmPassword
    let password = document.getElementById("password").value;
    let confirmPassword = document.getElementById("confirmPassword").value;
    if (password != confirmPassword) {
        $('#msgAlert').html('Mật khẩu không khớp').css('display', 'block');
        setTimeout(() => {
            $("#msgAlert").fadeOut('slow');
        }, 2000);
        return false;
    }

    //pass all validate
    return true;
    
    
}