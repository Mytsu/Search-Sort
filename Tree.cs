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

        public void InsertNode(Node newNode) {
            Node atual = this.root, pai = null;
            while(atual != null)
            {
                if(atual.data == newNode.data)
                {
                    // dados iguais, ignorar
                    return;
                }
                else if(atual.data > newNode.data)
                {
                    // valor atual > entrada, adicionar a esquerda
                    pai = atual;
                    atual = atual.left;
                }
                else if(atual.data < newNode.data)
                {
                    // valor atual < entrada, adicionar a direita
                    pai = atual;
                    atual = atual.right;
                }
            }
            count++;
            if(pai == null)
            {
                // arvore vazia, fazer deste a raiz
                root = newNode;
            }
            else
            {
                if (pai.data > newNode.data)
                {
                    pai.left = newNode;
                }
                else
                    pai.right = newNode;
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