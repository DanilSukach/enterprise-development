/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      fontFamily: {
        nunito: ['Nunito+Sans', 'sans-serif']
      },
      colors:{
        blue: '#4880FF',
        grey: '#273142',
        dark: '#1B2431',
        white: '#FFFFFF',
        border: "#313D4F",
        red: '#EF3826',
        table: '#323D4E',
      }
    },
  },
  plugins: [],
}
