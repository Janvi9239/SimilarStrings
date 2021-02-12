- The Levenshtein distance algorithm in the compute method is from stackover flow

- The output has some false positives for certain small strings‪ like FBI, RDN etc,. where the levenshtein distance is less than 2. 
This is a downside to the approach.