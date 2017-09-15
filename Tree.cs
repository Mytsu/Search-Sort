using System;

namespace SearchSort
{

    class Node
    {
        public int data;
        public Node left, right;
        public Node dad;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    abstract class Tree
    {
        public const int _PREORDER = 0;
        public const int _INORDER = 1;
        public const int _POSORDER = 2;

        public Node root;
        protected static int count = 0;
        
        public abstract void InsertNode(Node newNode);
        public abstract void Remover(int data);

        public Node AddNode(int data)
        {
            return new Node(data);
        }

        public int Altura(Node root)
        {
            if (root == null || root.left == null || root == null) return 0;
            else
            {
                return 1 + Program.Maior(a: Altura(root.left), b: Altura(root.right));
            }
        }

        static public void DisplayTree(Node root, int type)
        {
            if (root == null) return;
            switch (type)
            {
                case _PREORDER:
                    Console.Write(root.data + " ");
                    if (root.left != null)
                        DisplayTree(root.left, _PREORDER);
                    if (root.right != null)
                        DisplayTree(root.right, _PREORDER);
                    break;

                case _INORDER:
                    if (root.left != null)
                        DisplayTree(root.left, _INORDER);
                    Console.Write(root.data + " ");
                    if (root.right != null)
                        DisplayTree(root.right, _INORDER);
                    break;

                case _POSORDER:
                    if (root.left != null)
                        DisplayTree(root.left, _POSORDER);
                    if (root.right != null)
                        DisplayTree(root.left, _POSORDER);
                    Console.Write(root.data + " ");
                    break;
            }
        }

        public Node Pesquisa(Node root, int data)
        {
            if (root == null) return null;
            if (root.data == data) return root;
            else if (root.data > data && root.left != null)
            {
                return Pesquisa(root.left, data);
            }
            else if (root.data < data && root.right != null)
            {
                return Pesquisa(root.right, data);
            }
            else return null;
        }
    }

    class BinaryTree : Tree
    {

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int data)
        {
            root = new Node(data);
        }

        public override void InsertNode(Node newNode)
        {
            Node atual = this.root, pai = null;
            while (atual != null)
            {
                if (atual.data == newNode.data)
                {
                    // dados iguais, ignorar
                    return;
                }
                else if (atual.data > newNode.data)
                {
                    // valor atual > entrada, adicionar a esquerda
                    pai = atual;
                    atual = atual.left;
                }
                else if (atual.data < newNode.data)
                {
                    // valor atual < entrada, adicionar a direita
                    pai = atual;
                    atual = atual.right;
                }
            }
            count++;
            if (pai == null)
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
        public override void Remover(int data)
        {
            RemoverBT(this.root, data);
        }

        public void RemoverBT(Node root, int data)
        {
            Node atual = root, pai = null;
            while (atual.data != data && atual != null)
            {
                if (atual.data > data)
                {
                    pai = atual;
                    atual = atual.left;
                    continue;
                }
                else if (atual.data < data)
                {
                    pai = atual;
                    atual = atual.right;
                    continue;
                }
            }

            if (atual != null)
            {
                if (pai.data > atual.data)
                    if (atual.left != null)
                        pai.left = atual.left;
                    else if (atual.right != null)
                        pai.left = atual.right;
                    else pai.left = null;

                if (pai.data < atual.data)
                    if (atual.left != null)
                        pai.right = atual.left;
                    else if (atual.right != null)
                        pai.right = atual.right;
                    else pai.right = null;
            }
            atual = null;
        }
    }
    class AVLTree : Tree
    {
        public override void InsertNode(Node newNode)
        {
            InserirAVL(root, newNode);
        }

        protected void InserirAVL(Node root, Node newNode)
        {
            if(root == null)
            {
                this.root = newNode;
            }
            else
            {
                if (newNode.data < root.data)
                {
                    if (root.left == null)
                    {
                        root.left = newNode;
                        newNode.dad = root;
                        VerificarBalanceamento(root);
                    }
                    else
                    {
                        InserirAVL(root.left, newNode);
                    }
                }
                else if (newNode.data > root.data)
                {
                    if (root.right == null)
                    {
                        root.right = newNode;
                        newNode.dad = root;
                        VerificarBalanceamento(root);
                    }
                    else
                    {
                        InserirAVL(root.right, newNode);
                    }
                }
                else
                {
                    // No ja existe
                }
            }

        }

        public override void Remover(int data)
        {

        }

        public void VerificarBalanceamento(Node root)
        {

        }
    }
}