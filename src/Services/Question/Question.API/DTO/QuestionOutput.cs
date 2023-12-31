﻿using Microsoft.AspNetCore.Components.Forms;
using Question.API.Data.Models;

namespace Question.API.DTO
{
    public class QuestionOutput
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public QuestionLvlEnum Level { get; set; }
        public QuestionTypeEnum Type { get; set; }
        public bool IsFree { get; set; }

        public static implicit operator QuestionOutput(Data.Models.Question input)
        {
            var result = new QuestionOutput();
            result.Id = input.Id;
            result.Content = input.Content;
            result.Title = input.Title;
            result.Level = input.Level;
            result.Type = input.Type;
            result.IsFree = input.IsFree;

            return result;
        }
    }
}
