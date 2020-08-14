using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IQuizzService
    {
        int Add(QuizzDTO user);
        void Update(QuizzDTO user);

        void Save();
    }
}
