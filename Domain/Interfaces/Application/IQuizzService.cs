﻿using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application
{
    public interface IQuizzService
    {
        Task<int> AddQuizz(QuizzDTO user);
        void Update(QuizzDTO user);
        QuizzDTO GeyById(int id);
        List<Quizz> QuizzByProfessorID(string id);
        void Save();

        bool Delete(int id);
        bool EditPost(QuizzDTO dto);

     
    }
}
