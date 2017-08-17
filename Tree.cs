using System;

namespace SearchSort {

    class Node {
        public int data;
        public Node left, right;

        public Node(int data) {
            this.data = data;
            left = null;
            right = null;
        }
    }
    class BinaryTree {
        public Node root;
        static int count = 0;

        public BinaryTree() {
            root = null;
        }

        public BinaryTree(int data) {
            root = new Node(data);
        }

        public Node AddNode(int data) {
            return new Node(data);
        }

        public void InsertNode(Node root, Node newNode) {
            if (root == null) {
                this.root = root;
            } else if (root.data > newNode.data) {
                InsertNode(this.root.left, newNode);
            } else if (root.data < newNode.data) {
                InsertNode(root.right, newNode);
            }             
        }

        public int Altura(Node root) {
            if (root == null || root.left == null || root == null) return 0;
            else {
                return 1 + Program.Maior(a: Altura(root.left), b: Altura(root.right));
            }
        }
    }
}