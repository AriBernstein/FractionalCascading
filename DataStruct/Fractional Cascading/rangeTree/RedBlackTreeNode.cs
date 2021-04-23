using System;

namespace Fractional_Cascading {

    public class RBTreeNode {
        private int Data;
        private bool Leaf, Red;
        private RBTreeNode ParentNode, LeftChild, RightChild;

        public int GetData() {
            return Data;
        }

        public bool IsLeaf() {
            return Leaf;
        }

        public void MakeLeaf() {
            Leaf = true;
        }

        public void SetRed() {
            Red = true;
        }

        public void SetBlack() {
            Red = false;
        }

        public bool IsRed() {
            return Red;
        }

        public RBTreeNode Parent() {
            return ParentNode;
        }

        public void SetParent(RBTreeNode parent) {
            ParentNode = parent;
        }

        public RBTreeNode GrandParent() {
            return ParentNode.Parent();
        }

        public RBTreeNode Left() {
            return LeftChild;
        }

        public void SetLeft(RBTreeNode leftChild) {
            LeftChild = leftChild;
        }

        public RBTreeNode Right() {
            return RightChild;
        }

        public void SetRight(RBTreeNode rightChild) {
            RightChild = rightChild;
        }

        public int SubTreeSize() {
            int nodeCount = 0;
            void CountChildren(RBTreeNode n) {
                if (n == null) return;
                CountChildren(n.Left());
                CountChildren(n.Right());
                nodeCount++;
            }
            CountChildren(this);
            return nodeCount;
        }

        public int NumChildren() {
            return SubTreeSize() - 1;
        }
        
        public RBTreeNode(int data, bool leaf=false, bool red = true) {
            Data = data;
            Leaf = leaf;
            Red = red;
        }

        public String PrintSubTree(int verticalSpacing=1, int indentPerLevel=5,
                                   bool print=true) {
            return new RBTreeHelper().PrintSubTree(this, verticalSpacing,
                                                   indentPerLevel, print);
        }

        // Overide default methods and operators
        public override String ToString() {
            String color = IsRed() ? "Red" : "Black";
            String leaf = IsLeaf() ? "true" : "false"; 
            return $"Data: {Data}, Color: {color}, Leaf: {leaf}";
        }

        public override bool Equals(object obj) {
            var nodeForComparison = obj as RBTreeNode;
            if (nodeForComparison == null) return false;
            else if (nodeForComparison.GetData() != Data) return false;
            else return true;
        }

        public static bool operator ==(RBTreeNode x, RBTreeNode y) {
            
            // Handle null equality check
            if (System.Object.ReferenceEquals(x, null)) {
                if (System.Object.ReferenceEquals(y, null)) return true;
                else return false;

            // Otherwise compare class instances
            } else return x.Equals(y);
        }

        public static bool operator !=(RBTreeNode x, RBTreeNode y) { 
            return !(x == y);
        }

        public static bool operator >(RBTreeNode x, RBTreeNode y) {
            return x.GetData() > y.GetData();
        }

        public static bool operator >=(RBTreeNode x, RBTreeNode y) {
            return x.GetData() >= y.GetData();
        }

        public static bool operator <(RBTreeNode x, RBTreeNode y) {
            return x.GetData() < y.GetData();
        }

        public static bool operator <=(RBTreeNode x, RBTreeNode y) {
            return x.GetData() <= y.GetData();
        }
        
        public override int GetHashCode() {
            return Data.GetHashCode();
        }
    }
}
