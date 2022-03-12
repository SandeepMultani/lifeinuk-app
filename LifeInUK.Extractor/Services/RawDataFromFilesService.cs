using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LifeInUK.Extractor.Models;
using LifeInUK.Extractor.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LifeInUK.Extractor.Services
{
    public class RawDataFromFilesService : IRawDataService
    {
        private readonly ILogger<RawDataFromFilesService> _logger;
        private readonly ExtractorOptions _extractorOptions;

        public RawDataFromFilesService(
            ILogger<RawDataFromFilesService> logger,
            IOptions<ExtractorOptions> extractorOptions)
        {
            if (extractorOptions == null || extractorOptions.Value == null)
                throw new ArgumentNullException(nameof(extractorOptions));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _extractorOptions = extractorOptions.Value;
        }

        public IEnumerable<QuestionRawData> Get()
        {
            foreach (string file in Directory.EnumerateFiles($"{AppDomain.CurrentDomain.BaseDirectory}{_extractorOptions.RawDataPath}", $"*.{_extractorOptions.RawDataFileExtension}"))
            {
                yield return new QuestionRawData{
                    RawData = File.ReadAllText(file),
                    FileName = file
                };
            }
        }
    }
}