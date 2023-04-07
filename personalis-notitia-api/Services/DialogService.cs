﻿namespace personalis_notitia_api.Services;

public class DialogService : IDialogService
{
    private static readonly string[] DialogOptions =
    {
        "Sorry, I didn't understand that.",
        "I'm not sure what you mean.",
        "Could you please rephrase that?",
        "I'm afraid I can't answer that.",
        "Let me think about that for a moment...",
        "I don't have an answer to that, but I can look it up for you!",
        "Interesting question! Unfortunately, I don't have an answer for you right now.",
        "I'm just a dummy response, but I'm happy to chat with you!",
        "Why do you ask?",
        "That's a great question! Let me see if I can find the answer.",
        "I'm not programmed to answer that.",
        "I'm sorry, Dave. I'm afraid I can't do that.",
        "I'm having trouble understanding your question. Can you please clarify?",
        "That's outside the scope of my programming, but I'm happy to chat with you!",
        "I'm a language model created by OpenAI. What can I help you with today?",
    };


    public async Task<string> GetDialogResponseAsync()
    {
        var random = new Random();
        return await Task.FromResult(DialogOptions[random.Next(DialogOptions.Length)]);
    }
}