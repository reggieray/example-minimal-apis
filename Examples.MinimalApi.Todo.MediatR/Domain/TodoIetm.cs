﻿namespace Examples.MinimalApi.Todo.MediatR.Domain
{
    public class TodoIetm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}