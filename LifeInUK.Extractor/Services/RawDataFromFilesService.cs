using System;
using System.Collections.Generic;
using System.IO;
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
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (extractorOptions == null || extractorOptions.Value == null)
                throw new ArgumentNullException(nameof(extractorOptions));

            _logger = logger;
            _extractorOptions = extractorOptions.Value;
        }

        public IEnumerable<string> Get()
        {
            foreach (string file in Directory.EnumerateFiles($"{AppDomain.CurrentDomain.BaseDirectory}{_extractorOptions.RawDataPath}", $"*.{_extractorOptions.RawDataFileExtension}"))
            {
                _logger.LogInformation("Reading file {filename}", file);
                yield return File.ReadAllText(file);
            }
        }
    }
}