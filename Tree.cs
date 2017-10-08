using System;
using System.Collections.Generic;

namespace SearchSort
{
    #region Abstract Tree
    class Node
    {
        public int data;
        public Node left, right;
        public Node dad;
        public int balanceamento;

        public Node()
        {
            left = null;
            right = null;
            data = int.MaxValue;
        }

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

        public List<Node> InOrder()
        {
            List<Node> ret = new List<Node>();
            InOrder(this.root, ret);
            return ret;
        }

        private void InOrder(Node root, List<Node> lista)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.left, lista);
            lista.Add(root);
            InOrder(root.right, lista);
        }
    }
    #endregion

    #region Binary Tree
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
    #endregion

    #region AVL Tree
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
            RemoverAVL(this.root, data);
        }

        private void RemoverAVL(Node root, int data)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                if (root.data > data)
                {
                    RemoverAVL(root.left, data);
                }
                else if (root.data < data)
                {
                    RemoverAVL(root.right, data);
                }
                else if (root.data == data)
                {
                    RemoverNoEncontrado(root);
                }
            }
        }

        private void RemoverNoEncontrado(Node aRemover)
        {
            Node r;

            if (aRemover.left == null || aRemover.right == null)
            {
                if (aRemover.dad == null)
                {
                    this.root = null;
                    aRemover = null;
                    return;
                }
                r = aRemover;
            }
            else
            {
                r = Sucessor(aRemover);
                aRemover.data = r.data;
            }

            Node p;

            if (r.left != null)
            {
                p = r.left;
            }
            else
            {
                p = r.right;
            }

            if (p != null)
            {
                p.dad = r.dad;
            }

            if (r.dad == null)
            {
                this.root = p;
            }
            else
            {
                if (r == r.dad.left)
                {
                    r.dad.left = p;
                }
                else
                {
                    r.dad.right = p;
                }
                VerificarBalanceamento(p);
            }
            r = null;
        }

        public Node Sucessor(Node q)
        {
            if (q.right != null)
            {
                Node r = q.right;
                while (r.left != null)
                {
                    r = r.left;
                }
                return r;
            }
            else
            {
                Node p = q.dad;
                while (p != null && q == p.right)
                {
                    q = p;
                    p = q.dad;
                }
                return p;
            }
        }

        public void VerificarBalanceamento(Node root)
        {
            SetBalanceamento(root);
            int balanceamento = root.balanceamento;

            if (balanceamento == -2)
            {
                if (Altura(root.left.left) >= Altura(root.left.right))
                {
                    root = RotacaoDireita(root);
                }
                else
                {
                    root = DuplaRotacaoEsquerdaDireita(root);
                }
            }
            else if (balanceamento == 2)
            {
                if (Altura(root.right.right) >= Altura(root.right.left))
                {
                    root = RotacaoEsquerda(root);
                }
                else
                {
                    root = DuplaRotacaoDireitaEsquerda(root);
                }
            }
            if (root.dad != null)
            {
                VerificarBalanceamento(root.dad);
            }
            else
            {
                this.root = root;
            }
        }

        private Node RotacaoDireita(Node no)
        {
            Node left = no.left;
            left.dad = no.dad;

            no.left = left.right;

            if (no.left != null)
            {
                no.left.dad = no;
            }

            left.right = no;
            no.dad = left;

            if (left.dad != null)
            {
                if (left.dad.right.Equals(no)) {
                    left.dad.right = left;
                }
                else if (left.dad.left.Equals(no))
                {
                    left.dad.left = left;
                }
            }

            SetBalanceamento(no);
            SetBalanceamento(left);

            return left;
        }

        private Node RotacaoEsquerda(Node no)
        {
            Node right = no.right;
            right.dad = no.dad;

            no.right = right.left;

            if (no.right != null)
            {
                no.right.dad = no;
            }

            right.left = no;
            no.dad = right;

            if (right.dad != null)
            {
                if (right.dad.right.Equals(no))
                {
                    right.dad.right = right;
                }
                else if (right.dad.left.Equals(no))
                {
                    right.dad.left = right;
                }
            }

            SetBalanceamento(no);
            SetBalanceamento(right);

            return right;
        }

        private Node DuplaRotacaoEsquerdaDireita(Node no)
        {
            no.left = RotacaoEsquerda(no.left);
            return RotacaoDireita(no);
        }

        private Node DuplaRotacaoDireitaEsquerda(Node no)
        {
            no.right = RotacaoDireita(no.right);
            return RotacaoEsquerda(no);
        }

        private void SetBalanceamento(Node no)
        {
            no.balanceamento = Altura(no.right) - Altura(no.left);
        }
    }
    #endregion

    /*
    * Arvore Rubro Negra baseada no design de Arsenalist 
    * (https://github.com/Arsenalist/Red-Black-Tree-Java-Implementation)
    * 
    * Codigo convertido para C# por Jonathan Arantes
    */

    #region RedBlack Tree
    class RedBlackNode
    {
        public const int _RED = 0;
        public const int _BLACK = 1;
        public int numLeft;
        public int numRight;
        public int cor;
        public int data;
        public RedBlackNode left, right;
        public RedBlackNode dad;
        public int balanceamento;

        public RedBlackNode()
        {
            cor = _BLACK;
            numLeft = 0;
            numRight = 0;
            dad = null;
            left = null;
            right = null;
            data = int.MaxValue;
        }

        public RedBlackNode(int data) : this()
        {            
            this.data = data;
        }

    }

    class RedBlackTree
    {

        private static RedBlackNode nil = new RedBlackNode();
        private new RedBlackNode root = nil;

        public RedBlackTree() 
        {
            root.left = nil;
            root.right = nil;
            root.dad = nil;
        }

        private void LeftRotate(RedBlackNode node) 
        {
            LeftRotateFixUp(node);

            RedBlackNode aux;
            aux = node.right;
            node.right = aux.left;
            
            if(IsNil(aux.left)) 
                aux.left.dad = node;

            aux.dad = node.dad;

            if(IsNil(node.dad))
                root = aux;

            else
                if(node.dad.left == node)
                    node.dad.left = aux;
                
                else
                    node.dad.right = aux;

            aux.left = node;
            node.dad = aux;
        }

        private void LeftRotateFixUp(RedBlackNode node)
        {
            if(IsNil(node.left) && IsNil(node.right.left))
            {
                node.numLeft = 0;
                node.numRight = 0;
                node.right.numLeft = 1;
            }
            
            else if(IsNil(node.left) && !IsNil(node.right.left))
                {
                    node.numLeft = 0;
                    node.numRight = 1 + node.right.left.numLeft 
                        + node.right.left.numRight;
                    node.right.numLeft = 2 + node.right.left.numLeft
                        + node.right.left.numRight;
                }
            
            else if(!IsNil(node.left) && IsNil(node.right.left))
                {
                    node.numRight = 0;
                    node.right.numLeft = 2 + node.left.numLeft + node.left.numRight;
                }
        }

        private void RightRotate(RedBlackNode node)
        {
            RightRotateFixUp(node);

            RedBlackNode aux = node.left;
            node.left = aux.right;

            if(!IsNil(aux.right))
                aux.right.dad = node;

            aux.dad = node.dad;

            if (IsNil(aux.dad))
                this.root = aux;

            else if (node.dad.right == node)
                node.dad.right = aux;

            else
                node.dad.left = aux;

            aux.right = node;

            node.right = aux;
        }

        private void RightRotateFixUp(RedBlackNode node)
        {
            if(IsNil(node.right) && IsNil(node.left.right))
            {
                node.numRight = 0;
                node.numLeft = 0;
                node.left.numRight = 1;
            }

            else if(IsNil(node.right) && !IsNil(node.left.right))
            {
                node.numRight = 0;
                node.numLeft = 1 + node.left.right.numRight + node.left.right.numLeft;
            }

            else if(!IsNil(node.right) && IsNil(node.left.right))
            {
                node.numLeft = 0;
                node.left.numRight = 2 + node.right.numRight + node.right.numLeft;
            }

            else
            {
                node.numLeft = 1 + node.left.right.numRight + node.left.right.numLeft;
                node.left.numRight = 3 + node.right.numRight + node.right.numLeft
                    + node.left.right.numRight + node.left.right.numLeft;
            }
        }

        public void Insert(int data)
        {
            InsertNode(new RedBlackNode(data));
        }
        
        public void InsertNode(RedBlackNode newNode) 
        {
            RedBlackNode y = nil;
            RedBlackNode x = this.root;

            while (!IsNil(x))
            {
                y = x;

                if (newNode.data.CompareTo(x.data) < 0)
                {
                    x.numLeft++;
                    x = x.left;
                }

                else
                {
                    x.numRight++;
                    x = x.right;
                }
            }

            newNode.dad = y;

            if (IsNil(y))
                this.root = newNode;

            else if (newNode.data.CompareTo(y.data) < 0)
                y.left = newNode;

            else
                y.right = newNode;

            newNode.left = nil;
            newNode.right = nil;
            newNode.cor = RedBlackNode._RED;

            InsertFixUp(newNode);
        }

        private void InsertFixUp(RedBlackNode node)
        {

        }
        
        public void Remover(int data) 
        {
        
        }

        private bool IsNil(RedBlackNode node)
        {
            return node == nil;
        }

    }
    #endregion
}