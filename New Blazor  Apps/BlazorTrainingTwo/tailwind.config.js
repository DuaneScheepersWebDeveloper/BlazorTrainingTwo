/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./../**/*.{razor,html,cshtml}'],
    theme: {
        extend: {
            colors: {
                eclprim: '#054281',
            }
        },
    },
    plugins: [
        require('@tailwindcss/forms')
    ],
}