window.scrollToBottomOfChat = () => {
    document.getElementById('bottom-of-the-chat-screen')?.scrollIntoView({
        behavior: 'smooth',
        block: 'start'
    });
};
