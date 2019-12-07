﻿using Genome;
using IO;
using VariantAnnotation.Interface.SA;

namespace VariantAnnotation.NSA
{
    public sealed class SuppInterval : ISuppIntervalItem
    {
        public int Start { get; }
        public int End { get; }
        public IChromosome Chromosome { get; }
        private readonly string _jsonString;

        private SuppInterval(IChromosome chromosome, int start, int end, string jsonString)
        {
            Chromosome  = chromosome;
            Start       = start;
            End         = end;
            _jsonString = jsonString;
        }

        public static SuppInterval Read(ExtendedBinaryReader reader)
        {
            string ensemblName = reader.ReadAsciiString();
            string ucscName    = reader.ReadAsciiString();
            ushort chromIndex  = reader.ReadOptUInt16();
            var chromosome     = new Chromosome(ucscName, ensemblName, chromIndex);

            var start       = reader.ReadOptInt32();
            var end         = reader.ReadOptInt32();
            var jsonString  = reader.ReadString();

            return new SuppInterval(chromosome, start, end, jsonString);
        }

        public string GetJsonString() => _jsonString;
    }
}