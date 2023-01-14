﻿using System.Collections.Generic;

namespace WebAPIAutores.Common.Responses
{
    public class GenericResponse<TObject>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TObject Result { get; set; }
        public List<TObject> ListResults { get; set; }
        public string ErrorMessage { get; set; }
        public int TruePasswordHash { get; set; }
    }
}
