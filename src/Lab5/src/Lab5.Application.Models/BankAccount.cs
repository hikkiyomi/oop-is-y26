namespace Lab5.Application.Models;

public record BankAccount(
    string Username,
    string Number,
    string Pin,
    int Balance);