﻿using System.Collections.Generic;
using Genome;
using IO;
using VariantAnnotation.Caches;
using VariantAnnotation.IO.Caches;

namespace SAUtils.AAConservation
{
    public static class AaConservationUtilities
    {
        public static TranscriptCacheData GetTranscriptData(IDictionary<ushort, IChromosome> refIndexToChromosome, string transcriptCachePrefix)
        {
            using var transcriptCacheReader = new TranscriptCacheReader(
                FileUtilities.GetReadStream(CacheConstants.TranscriptPath(transcriptCachePrefix)));
            return transcriptCacheReader.Read(refIndexToChromosome);
        }

    }
}