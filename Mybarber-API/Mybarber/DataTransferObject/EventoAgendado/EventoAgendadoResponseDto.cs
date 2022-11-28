﻿using System;

namespace Mybarber.DataTransferObject.EventoAgendado
{
    public class EventoAgendadoResponseDto
    {
        public int IdEventoAgendado { get; set; }
        public string NomeEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan Duracao { get; set; }
        public Guid BarbeirosId { get; set; }
        public Guid BarbeariasId { get; set; }
       
    }
}