using Mybarber.Exceptions;
using System;

namespace Mybarber.Helpers.ToRead
{
    public static class ReadEmailAgendamento
    {
        public static string GetHTMLAgendamento(string tipoHtml, string name, string servico, string barbeiro, DateTime horario, string nomeBarbearia) 
        {


          



            if (tipoHtml == "EmailAgendamento")
            {
                string html = "<div class='header' style='" +
                   "background-color: #202020;" +
                   "background-image: linear-gradient(to top left, rgb(0, 0, 0), #444444);" +
                   "border-radius: 10px 10px 0 0;" +
                   "padding: .5rem;" +
                   "display: flex;" +
                   "justify-content: center;" +
                   "text-align: center;" +
                   "width: 15.4rem'>" +
                   "<h1 style='" +
                   "width: 15.4rem;" +
                   "color: #fff;" +

                   "font-weight: 400;" +
                   "font-size: 1rem;" +
                   "text-align: center;" +
                   "border-bottom: 1px solid #B78865'>" +
                   "Agendamento Realizado com Sucesso</h1>" +
                   "</div>" +
                   "<div class='content' style='" +
                   "width: 15.4rem;" +

                   "font-weight: 400;" +
                   "font-size: .7rem;" +
                   "padding: .5rem;" +
                   "text-align: center'>" +
                   "<p>Olá, <span style='font-weight: 700'>{name}!</span></p>" +
                   "<p>Seu agendamento com o barbeiro <span style='font-weight: 700'>" +
                   " {nameBarbeiro} </span>" +
                   " às <span style='font-weight: 700'>" +
                   "{horas}h </span>" +
                   " do dia <span style='font-weight: 700'> {dia} </span> de <span style='font-weight: 700'> {mes} </span>" +
                   "foi realizado com sucesso.</p>" +
                   "</div>" +

                   "<div class= 'footer' style='" +
                   "background-color: #B78865;" +
                   "background-image: linear-gradient(to top left, #d1996e, #B78865);" +
                   "font-size: .6rem;" +
                   "text-align: center;" +
                   "padding: .5rem;" +
                   "width: 15.4rem;" +
                   "border-radius: 0 0 10px 10px'>" +
                   " <p> Obrigado por agendar na <span style='font-weight: 700'> {nomeBarbearia}. </span>" +
                   "</p>" +
                   "</div>";

                //string html = " <style> span " +
                //           "{font-weight: bold;}" +
                //           ".header {background-color: #202020;" +
                //           "background-image: linear-gradient(to top left, rgb(0, 0, 0), #444444);" +
                //           "border-radius: 10px 10px 0 0;" +
                //           "padding: .5rem;" +
                //           "display: flex;" +
                //           "justify-content: center;" +
                //           "text-align: center;" +
                //           "width: 15.4rem;}" +
                //           ".header h1 { width: 15.4rem;" +
                //           "color: #fff;" +
                //           "font-family: 'Quicksand', sans-serif;" +
                //           "font-weight: 400;" +
                //           "font-size: 1rem;" +
                //           "text-align: center;" +
                //           "border-bottom: 1px solid #B78865;}" +
                //           ".content {width: 15.4rem;" +
                //           "font-family: 'Roboto', sans-serif;" +
                //           "font-weight: 400;" +
                //           "font-size: .7rem;" +
                //           "padding: .5rem;" +
                //           "text-align: center;}" +
                //           ".footer {background-color: #B78865;" +
                //           "background-image: linear-gradient(to top left, #d1996e, #B78865);" +
                //           "font- family: 'Roboto', sans-serif;" +
                //           "font-size: .6rem;" +
                //           "text-align: center;" +
                //           "padding: .5rem; " +
                //           "width: 15.4rem;" +
                //           "border-radius: 0 0 10px 10px;}" +
                //           "</style>" +
                //           "<div class='header'>" +
                //           "<h1>Agendamento Realizado com Sucesso</h1>" +
                //           "</div>" +
                //           "<div class='content'>" +
                //           "<p>Olá, <span>{name}!</span></p>" +
                //           "<p>Seu agendamento com o barbeiro <span> {nameBarbeiro} </span> às <span> {horas}h </span> do dia <span> {dia} </span> de <span> {mes} </span>" +
                //           " foi realizado com sucesso.</p></div>" +
                //           "<div class= 'footer'>" +
                //           "<p> Obrigado por agendar na <span> {nomeBarbearia}.</span></p></div>";


                return html.Replace("{name}", name)
                                .Replace("{nameBarbeiro}", barbeiro)
                                .Replace("{horas}", horario.ToString("t"))
                                .Replace("{dia}", horario.ToString("dd"))
                                .Replace("{nomeBarbearia}", nomeBarbearia)
                                .Replace("{mes}", horario.ToString("Y"));
                 

               
                    
            }
            else if (tipoHtml == "EmailCancelamento")
            {


                string html="<div class='header' style='" +
                    "background-color: #202020;" +
                    "background-image: linear-gradient(to top left, rgb(0, 0, 0), #444444);" +
                    "border-radius: 10px 10px 0 0;" +
                    "padding: .5rem;" +
                    "display: flex;" +
                    "justify-content: center;" +
                    "text-align: center;" +
                    "width: 15.4rem'>" +
                    "<h1 style='" +
                    "width: 15.4rem;" +
                    "color: #fff;" +
                  
                    "font-weight: 400;" +
                    "font-size: 1rem;" +
                    "text-align: center;" +
                    "border-bottom: 1px solid #B78865'>" +
                    "Agendamento Cancelado</h1>" +
                    "</div>" +
                    "<div class='content' style='" +
                    "width: 15.4rem;" +
                    
                    "font-weight: 400;" +
                    "font-size: .7rem;" +
                    "padding: .5rem;" +
                    "text-align: center'>" +
                    "<p>Olá, <span style='font-weight: 700'>{name}!</span></p>" +
                    "<p>Seu agendamento com o barbeiro <span style='font-weight: 700'>" +
                    " {nameBarbeiro} </span>" +
                    " às <span style='font-weight: 700'>" +
                    "{horas}h </span>" +
                    " do dia <span style='font-weight: 700'> {dia} </span> de <span style='font-weight: 700'> {mes} </span>" +
                    "foi <span style='font-weight: 700'>CANCELADO</span>, entre em contato para mais informações.</p>" +
                    "</div>" +

                    "<div class= 'footer' style='" +
                    "background-color: #B78865;" +
                    "background-image: linear-gradient(to top left, #d1996e, #B78865);" +
                    "font-size: .6rem;" +
                    "text-align: center;" +
                    "padding: .5rem;" +
                    "width: 15.4rem;" +
                    "border-radius: 0 0 10px 10px'>" +
                    " <p> Obrigado por escolher a <span style='font-weight: 700'> {nomeBarbearia}. </span>" +
                    "</p>" +
                    "</div>";








                //string html = " <style> span " +
                //           "{font-weight: bold;}" +
                //           ".header {background-color: #202020;" +
                //           "background-image: linear-gradient(to top left, rgb(0, 0, 0), #444444);" +
                //           "border-radius: 10px 10px 0 0;" +
                //           "padding: .5rem;" +
                //           "display: flex;" +
                //           "justify-content: center;" +
                //           "text-align: center;" +
                //           "width: 15.4rem;}" +
                //           ".header h1 { width: 15.4rem;" +
                //           "color: #fff;" +
                //           "font-family: 'Quicksand', sans-serif;" +
                //           "font-weight: 400;" +
                //           "font-size: 1rem;" +
                //           "text-align: center;" +
                //           "border-bottom: 1px solid #B78865;}" +
                //           ".content {width: 15.4rem;" +
                //           "font-family: 'Roboto', sans-serif;" +
                //           "font-weight: 400;" +
                //           "font-size: .7rem;" +
                //           "padding: .5rem;" +
                //           "text-align: center;}" +
                //           ".footer {background-color: #B78865;" +
                //           "background-image: linear-gradient(to top left, #d1996e, #B78865);" +
                //           "font- family: 'Roboto', sans-serif;" +
                //           "font-size: .6rem;" +
                //           "text-align: center;" +
                //           "padding: .5rem; " +
                //           "width: 15.4rem;" +
                //           "border-radius: 0 0 10px 10px;}" +
                //           "</style>" +
                //           "<div class='header'>" +
                //           "<h1>Agendamento Cancelado</h1>" +
                //           "</div>" +
                //           "<div class='content'>" +
                //           "<p>Olá, <span>{name}!</span></p>" +
                //           "<p>Seu agendamento com o barbeiro <span> {nameBarbeiro} </span> às <span>" +
                //           " {horas}h </span> do dia <span> {dia} </span> de <span> {mes} </span>" +
                //           " foi <span>CANCELADO</span>, entre em contato para mais informações.</p></div>" +
                //           "<div class= 'footer'>" +
                //           "<p> Obrigado por escolher a <span> {nomeBarbearia}. </span></p></div>";


                return html.Replace("{name}", name)
                                 .Replace("{nameBarbeiro}", barbeiro)
                                 .Replace("{horas}", horario.ToString("t"))
                                 .Replace("{dia}", horario.ToString("dd"))
                                 .Replace("{nomeBarbearia}", nomeBarbearia)
                                 .Replace("{mes}", horario.ToString("Y"));

            }
            else
            {

                throw new ViewException("Email.Was.Fail");
            }
           
        }
    }
}
