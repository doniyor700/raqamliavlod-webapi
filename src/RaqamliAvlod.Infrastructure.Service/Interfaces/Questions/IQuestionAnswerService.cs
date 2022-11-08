﻿using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface IQuestionAnswerService
    {
        Task<bool> CreateAsync(QuestionAnswerCreateDto dto);
        Task<bool> UpdateAsync(long id, QuestionAnswerUpdateDto dto);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<QuestionAnswerViewModel>> GetAllAsync(long questionId, PaginationParams? @params = null);
    }
}