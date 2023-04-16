
function ChangeTheme(themeName) {
var theme = $("#theme");
var newUrl = `/lib/bootstrap-themes/${themeName}/bootstrap.css`
console.log(newUrl, theme.attr('href'));
theme.attr('href', newUrl);
}



ChangeTheme("Candy");