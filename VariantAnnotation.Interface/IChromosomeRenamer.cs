﻿namespace VariantAnnotation.Interface
{
    public interface IChromosomeRenamer
    {
        int NumRefSeqs { get; }
        string GetEnsemblReferenceName(string ucscReferenceName, bool useOriginalOnFailedLookup = true);
        ushort GetReferenceIndex(string referenceName);
		string GetEnsemblReferenceName(int referenceIndex);
		string GetUcscReferenceName(int referenceIndex);
	}
}
