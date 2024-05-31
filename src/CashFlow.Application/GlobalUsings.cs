global using AutoMapper;
global using CashFlow.Application.AutoMapper;
global using CashFlow.Application.UseCases.Expenses.Delete;
global using CashFlow.Application.UseCases.Expenses.GetAll;
global using CashFlow.Application.UseCases.Expenses.GetById;
global using CashFlow.Application.UseCases.Expenses.Register;
global using CashFlow.Application.UseCases.Expenses.Reports.Excel;
global using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
global using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
global using CashFlow.Application.UseCases.Expenses.Update;
global using CashFlow.Communication.Requests;
global using CashFlow.Communication.Responses;
global using CashFlow.Domain.Abstractions.Repositories;
global using CashFlow.Domain.Abstractions.Repositories.Expenses;
global using CashFlow.Domain.Entities;
global using CashFlow.Domain.Extensions;
global using CashFlow.Domain.Reports;
global using CashFlow.Exception;
global using CashFlow.Exception.ExceptionBase;
global using ClosedXML.Excel;
global using FluentValidation;
global using Microsoft.Extensions.DependencyInjection;
global using MigraDoc.DocumentObjectModel;
global using PdfSharp.Fonts;
global using System.Reflection;


