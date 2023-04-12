﻿using System;
using QuestionTwo;

namespace CaseStudy
{
    [Serializable]
    public class ReceiptEntity
    {
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }

    }

    public class BoundingPoly
    {
        public List<Vertex> Vertices { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}

