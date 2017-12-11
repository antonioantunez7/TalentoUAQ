﻿using System;
using TalentoUAQ.Models;
using TalentoUAQ.Views;
using Xamarin.Forms;

namespace TalentoUAQ
{
    public class MainPage : TabbedPage
    {
        public MainPage(Usuarios usuario)
        {
            Page buscador, notificaciones, curriculum, cuenta = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    buscador = new NavigationPage(new Buscador())
                    {
                        Title = "Buscador"
                    };

                    notificaciones = new NavigationPage(new Notificaciones())
                    {
                        Title = "Notificaciones"
                    };

                    curriculum = new NavigationPage(new Curriculum())
                    {
                        Title = "Curriculum"
                    };

                    cuenta = new NavigationPage(new Cuenta(usuario))
                    {
                        Title = "Cuenta"
                    };



                    buscador.Icon = "acerca.png";
                    notificaciones.Icon = "acerca.png";
                    curriculum.Icon = "acerca.png";
                    cuenta.Icon = "acerca.png";
                    break;
                default:
                    buscador = new Buscador()
                    {
                        Title = "Buscador"
                    };

                    notificaciones = new Notificaciones()
                    {
                        Title = "Notificaciones"
                    };

                    curriculum = new Curriculum()
                    {
                        Title = "Curriculum"
                    };

                    cuenta = new Cuenta(usuario)
                    {
                        Title = "Cuenta"
                    };

                    break;
            }

            Children.Add(buscador);
            Children.Add(notificaciones);
            Children.Add(curriculum);
            Children.Add(cuenta);
            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
