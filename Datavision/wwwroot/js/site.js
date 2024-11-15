// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    'use strict';

    /**
     * element toggle function
     */
    const elemToggleFunc = function (elem) { elem.classList.toggle("active"); }

    /**
     * header sticky & go to top
     */
    const header = document.querySelector("[data-header]");
    const goTopBtn = document.querySelector("[data-go-top]");

    window.addEventListener("scroll", function () {
        if (window.scrollY >= 10) {
            header.classList.add("active");
            goTopBtn.classList.add("active");
        } else {
            header.classList.remove("active");
            goTopBtn.classList.remove("active");
        }
    });

    /**
     * Load and Apply Translations
     */
    const loadTranslations = async (language) => {
        const response = await fetch('./assets/json/translations.json');
        const translations = await response.json();
        return translations[language];
    };

    const updateContent = (translations) => {
        document.querySelector('.hero-title').textContent = translations.title;
        document.querySelector('.btn-primary').textContent = translations.btnGetInTouch;
        document.querySelector('#about').querySelector('.section-title').textContent = translations.aboutIS;
        document.querySelector('#skills').querySelector('.section-title').textContent = translations.ideFeatures;
        document.querySelector('#portfolio').querySelector('.section-title').textContent = translations.popularIS;
        document.querySelector('#contact').querySelector('.section-title').textContent = translations.contacts;
        document.querySelector('#about').querySelector('.section-subtitle').textContent = translations.subtitleaboutIS;
    };

    const languageSelect = document.getElementById('lang');
    if (languageSelect) {
        languageSelect.addEventListener('change', async (event) => {
            const selectedLanguage = event.target.value;
            const translations = await loadTranslations(selectedLanguage);
            updateContent(translations);
        });
    }

    /**
     * navbar toggle
     */
    const navToggleBtn = document.querySelector("[data-nav-toggle-btn]");
    const navbar = document.querySelector("[data-navbar]");

    if (navToggleBtn && navbar) {
        navToggleBtn.addEventListener("click", function () {
            elemToggleFunc(navToggleBtn);
            elemToggleFunc(navbar);
            elemToggleFunc(document.body);
        });
    }

    /**
     * skills toggle
     */
    const toggleBtnBox = document.querySelector("[data-toggle-box]");
    const toggleBtns = document.querySelectorAll("[data-toggle-btn]");
    const skillsBox = document.querySelector("[data-skills-box]");

    if (toggleBtnBox && skillsBox && toggleBtns.length > 0) {
        for (let i = 0; i < toggleBtns.length; i++) {
            toggleBtns[i].addEventListener("click", function () {
                elemToggleFunc(toggleBtnBox);
                for (let j = 0; j < toggleBtns.length; j++) { elemToggleFunc(toggleBtns[j]); }
                elemToggleFunc(skillsBox);
            });
        }
    }

    /**
     * Toggle visibility between register and login forms
     */
    const toggleRegister = document.getElementById('toggleRegister');
    const toggleLogin = document.getElementById('toggleLogin');
    if (toggleRegister && toggleLogin) {
        toggleRegister.addEventListener('click', function (e) {
            e.preventDefault();
            document.getElementById('Register_Section').style.display = 'block';
            document.getElementById('Login_Section').style.display = 'none';
        });

        toggleLogin.addEventListener('click', function (e) {
            e.preventDefault();
            document.getElementById('Login_Section').style.display = 'block';
            document.getElementById('Register_Section').style.display = 'none';
        });
    }

    /**
     * dark & light theme toggle
     */
    const themeToggleBtn = document.querySelector("[data-theme-btn]");
    if (themeToggleBtn) {
        themeToggleBtn.addEventListener("click", function () {
            elemToggleFunc(themeToggleBtn);

            if (themeToggleBtn.classList.contains("active")) {
                document.body.classList.remove("dark_theme");
                document.body.classList.add("light_theme");
                localStorage.setItem("theme", "light_theme");
            } else {
                document.body.classList.add("dark_theme");
                document.body.classList.remove("light_theme");
                localStorage.setItem("theme", "dark_theme");
            }
        });

        /**
         * Apply last selected theme from localStorage
         */
        if (localStorage.getItem("theme") === "light_theme") {
            themeToggleBtn.classList.add("active");
            document.body.classList.remove("dark_theme");
            document.body.classList.add("light_theme");
        } else {
            themeToggleBtn.classList.remove("active");
            document.body.classList.remove("light_theme");
            document.body.classList.add("dark_theme");
        }
    }

    /**
     * Load More IS Functionality
     */
    const additionalIS = [
        {
            title: "Transaction Processing System",
            imgSrc: "./assets/images/tps.png",
            date: "TPS é usado para recolher, armazenar, modificar </br> e recuperar dados relacionados </br> com transações comerciais.",
            for: "modal-toggle4"
        },
        {
            title: "Customer Relationship Management",
            imgSrc: "./assets/images/CRM-img.png",
            date: "CRM gere e analisa as interações </br> e os dados dos clientes para melhorar </br> o serviço ao cliente.",
            for: "modal-toggle5"
        },
        {
            title: "Supply Chain Management",
            imgSrc: "./assets/images/SCM-img.png",
            date: "SCM gere o fluxo de bens e serviços, melhora </br> a eficiência, reduz custos, aumenta a qualidade </br> e garante a entrega pontual dos produtos.",
            for: "modal-toggle6"
        },
    ];

    let loadedISIndex = 0;
    const numberToLoad = 3;
    const loadMoreBtn = document.getElementById('loadMoreBtn');
    const projectList = document.querySelector('.project-list');

    if (loadMoreBtn && projectList) {
        loadMoreBtn.addEventListener('click', function () {
            if (loadMoreBtn.textContent === "Ver mais") {
                const endIndex = loadedISIndex + numberToLoad;
                const IsSlice = additionalIS.slice(loadedISIndex, endIndex);

                if (IsSlice.length === 0) {
                    loadMoreBtn.style.display = 'none';
                    return;
                }

                IsSlice.forEach(IS => {
                    const li = document.createElement('li');
                    li.innerHTML = `
            <div class="project-card">

              <figure class="card-banner">
                <img src="${IS.imgSrc}" class="w-100" alt="${IS.title}">
              </figure>

              <div class="card-content">
                <h3 class="h4 card-title">${IS.title}</h3>
                <time class="publish-date" datetime="${IS.date}">${IS.date}</time>
                
                <label for="${IS.for}" class="learn-more-btn">Saiba mais</label>
              </div>
            </div>
          `;
                    projectList.appendChild(li);
                });

                loadedISIndex = endIndex;
                loadMoreBtn.textContent = "Ver menos";
            } else {
                const idsToRemove = Math.min(loadedISIndex, numberToLoad);
                for (let i = 0; i < idsToRemove; i++) {
                    projectList.removeChild(projectList.lastChild);
                }

                loadedISIndex -= idsToRemove;
                loadMoreBtn.textContent = "Ver mais";

                if (loadedISIndex === 0) {
                    loadMoreBtn.style.display = 'block';
                }
            }
        });
    }
});
