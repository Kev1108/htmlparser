
// See https://aka.ms/new-console-template for more information

using htmlparsing;

HtmlParser parser = new HtmlParser("<section id=\"welcome-section\">\n      <h1 class=\"title\">Hey Im Kevin</h1>\n      <p class=\"belowtitle\" >a future web developer</p>  <section id=\"proyects\">\n      <h1 class=\"h1p\">These are my proyects</h1>\n      <div class=\"allproyects\">\n        <div class=\"proyectcontainer\"><a class=\"pns\"href=\"https://codepen.io/Kevin081996/pen/JjNzOjY\" target=\"_blank\">--Product Landing Page--\n          </a>");

string htmlstring = parser.DrawString();

Console.WriteLine(htmlstring);



